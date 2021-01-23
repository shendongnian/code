    class Game
    { // declares the class
        private static string[,] board = new string[3, 3]{
                                                  {" ", " ", " "}, // top row
                                                  {" ", " ", " "}, // middle row
                                                  {" ", " ", " "}  // bottom row
                                              };
        private static void print()
        {
            System.Console.WriteLine("\n {0} | {1} | {2} ", board[2, 0], board[2, 1], board[2, 2]);
            System.Console.WriteLine("------------");
            System.Console.WriteLine(" {0} | {1} | {2} ", board[1, 0], board[1, 1], board[1, 2]);
            System.Console.WriteLine("------------");
            System.Console.WriteLine(" {0} | {1} | {2} \n", board[0, 0], board[0, 1], board[0, 2]);
        }
        private static void calculateMoves()
        {
            System.Console.Write("The possible moves are: ");
            int n = 1; // this is used to list all possible moves.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == " ")
                    {
                        System.Console.Write("{0} ", n);
                    }
                    n++;
                }
            } // end print possible moves.
           
            System.Console.WriteLine(); // go to next line
        
        }
        static void Main()
        { // the main function, the program starts from (this is a method declartion)
            System.Console.WriteLine("\nWelcome to theelitenoob's simple tic tac toe game!");
            System.Console.WriteLine("Written in C#, released under the GPL.");
            System.Console.WriteLine("The board is 3 by 3, Type a number to place a move there.");
            System.Console.WriteLine("So 1 is bottom left and 9 is top right, like a standard keypad.\n");
            int winner = 0; // there is no winner yet.
            // write players piece
            System.Console.WriteLine("You are x");
            // create the board
            int move;
            print();
            calculateMoves();
            System.Console.Write("Please type in a move number: ");
            while (winner == 0 && int.TryParse(Console.ReadLine() , out move) )
            {
                move--;
                if (move == 0) board[0, 0] = "x";
                if (move == 1) board[0, 1] = "x";
                if (move == 2) board[0, 2] = "x";
                if (move == 3) board[1, 0] = "x";
                if (move == 4) board[1, 1] = "x";
                if (move == 5) board[1, 1] = "x";
                if (move == 6) board[2, 0] = "x";
                if (move == 7) board[2, 1] = "x";
                if (move == 8) board[2, 2] = "x";
              
                print();
                calculateMoves();
                System.Console.Write("Please type in a move number: ");
                
                
                /**/
            } // end while loop
        }
    }
