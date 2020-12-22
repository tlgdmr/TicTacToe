using System;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        //Track the game round to determine if the game is over.
        static int gameRound = 0;

        static void Main(string[] args)
        {

            //Created a variable to store status of the game.
            bool gameStatus = false;

            //Created a variable to store current player
            int currentPlayer = 0;

            //Created a char array to draw the default board.
            char[] gameMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            do
            {
                //Clear the console for every round
                Console.Clear();

                //Set the current player
                currentPlayer = GetNextPlayer(currentPlayer);

                //Shows the status of the game
                HeadsUpDisplay(currentPlayer);

                //Created a function that takes the char array to draw the updated board.
                DrawGameboard(gameMarkers);

                //Created a function that takes the current player and gameMarkers to do logic of the game.
                GameEngine(gameMarkers, currentPlayer);

                //Check the game status.
                gameStatus = isGameOver();

            } while (!gameStatus);


            //If the game is over.
            if (gameStatus)
            {
                Console.Clear();
                HeadsUpDisplay(currentPlayer);
                DrawGameboard(gameMarkers);

                Console.WriteLine("Game Over!");
            }
        }

        /// <summary>
        /// It checks if the game is over.
        /// </summary>
        /// <returns> true or false  </returns>
        private static bool isGameOver()
        {
            return gameRound == 9 ? true : false;
        }

        /// <summary>
        /// The logic of the game
        /// </summary>
        /// <param name="gameMarkers"></param>
        /// <param name="currentPlayer"></param>
        static void GameEngine(char[] gameMarkers, int currentPlayer)
        {
            bool notValidMove = true;
            do
            {
                if (int.TryParse(Console.ReadLine(), out int result) && (result > 0 && result < 10))
                {
                    char currentMarker = gameMarkers[result - 1];
                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Illegal move! Try again.");
                    }
                    else
                    {
                        gameMarkers[result - 1] = GetPlayerMarker(currentPlayer);

                        notValidMove = false;

                        gameRound++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value please select another placement.");
                }
            }
            while (notValidMove);

        }

        static char GetPlayerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }
            return 'X';
        }

        static void HeadsUpDisplay(int currentPlayer)
        {
            // Provide Instruction
            // A Greeting 
            Console.WriteLine("Welcome to the Tic-Tac-Toe Game!");


            // Display Player Sign, Player 1 is X and Player 2 is O
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();


            //  Who's turn is it ?
            // Instruct the User to Enter a Number Between 1 and 9
            Console.WriteLine($"Player {currentPlayer} to move, select 1 through 9 from the game board");
            Console.WriteLine();
        }

        static void DrawGameboard(char[] gameMarkers)
        {
            // Draw The Game Board 
            // Game Board Consists of 3 Rows and 3 Columns are numbered 1 through 9

            Console.WriteLine("///////////////////");
            Console.WriteLine("// +---+---+---+ //");
            Console.WriteLine($"// | {gameMarkers[0]} | {gameMarkers[1]} | {gameMarkers[2]} | //");
            Console.WriteLine("// +---+---+---+ //");
            Console.WriteLine($"// | {gameMarkers[3]} | {gameMarkers[4]} | {gameMarkers[5]} | //");
            Console.WriteLine("// +---+---+---+ //");
            Console.WriteLine($"// | {gameMarkers[6]} | {gameMarkers[7]} | {gameMarkers[8]} | //");
            Console.WriteLine("// +---+---+---+ //");
            Console.WriteLine("///////////////////");
            Console.WriteLine();

        }

        /// <summary>
        /// Getting the next player
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <returns>the current player</returns>
        static int GetNextPlayer(int currentPlayer)
        {
            if (currentPlayer.Equals(1))
            {
                return 2;
            }

            return 1;
        }
    }
}
