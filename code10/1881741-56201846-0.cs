    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace CSharp_Shell
    {
    
        public static class Program
        {
    
            static void printBoard(string [, ] board) {
                for (int i = 0; i < 4; i++) {
                    for (int j = 0; j < 4; j++) {
                        Console.Write(board[i, j] + " ");
                    }
                    Console.Write("\n");
                }
            }
    
            static bool isSafe(string [,] board, int row, int col)
            {
                int i, j;
               /* Check this row completely */
                for (i = 0; i < 4; i++)
                    if (board[row, i] == "Q")
                        return false;
    
                /* Check upper diagonal on left side */
                for (i=row, j=col; i>=0 && j>=0; i--, j--)
                    if (board[i, j] == "Q")
                        return false;
    
                /* Check bottom diagonal on right side */
                for (i=row, j=col; i<4 && j<4; i++, j++)
                    if (board[i, j] == "Q")
                        return false;
    
                /* Check lower diagonal on left side */
                for (i=row, j=col; j>=0 && i<4; i++, j--)
                    if (board[i, j] == "Q")
                        return false;
    
                /* Check upper diagonal on right side */
                for (i=row, j=col; j<4 && i>=0; i--, j++)
                    if (board[i, j] == "Q")
                        return false;
    
                    return true;
            }
                static bool solve8queen(string[,] board, int col)
                {
                    //base case
                    if(col >= 4) {
                        printBoard(board);
                        return true;
                    }
    
                    bool res = false;
                    //loop over rows
                    for(int row = 0; row < 4; row++)
                    {
                        //check if queen can be placed
                        if(isSafe(board, row, col))
                        {
                            //place the queen
                            board[row, col] = "Q";
    
    
                            
                            // Skip evaluating column 1
                            if(col + 1 == 1)
                                col++;
    
                            // Skip evaluating column 3
                            if(col + 1 == 3)
                                col++;
    
                            //explore next solution
                            res = solve8queen(board, col + 1) || res;
    
                            //Backtrack
                            board[row, col] = ".";
    
                        }
    
    
                    }
    
                    return false;
    
                }
    
            public static void Main()
            {
                string [,] board = {
    
                               {".", "Q", ".", "."},
                               {".", ".", ".", "Q"},
                               {".", ".", ".", "."},
                               {".", ".", ".", "."}
    
                             };
    
                solve8queen(board, 0);
                //printBoard(board);
    
            }
    
    
        }
    }
