        static void Main(string[] args)
        {
            MultiplyMatrix();
        }
        static void MultiplyMatrix()
        {
            int[,] metrix1 = new int[3,4] { { 1, 2,3,2 }, { 3, 4,5,6 }, { 5, 6,8,4 } };
            int[,] metrix2 = new int[4, 3] { { 2, 5, 3 }, { 4, 5, 1 }, { 8, 7, 9 }, { 3, 7, 2 } };
            int[,] metrixMultplied = new int[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                { 
                    for(int i=0;i<4;i++)
                    {
                        metrixMultplied[row, col] = metrixMultplied[row, col] + metrix1[row, i] * metrix2[i, col];
                        
                    }
                    Console.Write(metrixMultplied[row, col] + ", ");                   
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
