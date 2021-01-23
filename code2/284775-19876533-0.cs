     int[] grid = new int[9];//size of array
            
            Random randomNumber = new Random();//new random number
            var rowLength = grid.GetLength(0);
            var colLength = grid.GetLength(1);
            for (int row = 0; row < rowLength; row++)
            {
                
                    grid[col] = randomNumber.Next(4)+1;//Fills grid with numbers from
                                                            //1-4
                    Console.Write(String.Format("{0}\t", grid[col]));
                    //Displays array in console
                
                Console.WriteLine();
            }
