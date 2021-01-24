    using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main()
            {
                // matrix size
                int m = 5;
                int n = 4;
    
                // allocate matrix
                double[,] matrix = new double[m, n];
    
                // get random matrix entries
                double[] entries = GiveRandomNumbersWithoutRepetitions(-50.0, +50.0, m * n);
    
                // populate matrix with random entries
                int k = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = entries[k];
                        k++;
                    }
                }
    
                // print matrix
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
    
                // done
                Console.Write("Press any key to exit...");
                Console.ReadKey();
            }
    
            public static double[] GiveRandomNumbersWithoutRepetitions(double min, double max, int count)
            {
                Random random = new Random();
                double[] output = new double[count];
                int i = 0;
                while (i < count)
                {
                    double number = random.NextDouble() * (max - min) + min;
                    if (Array.IndexOf(output, number) > -1)
                    {
                        continue;
                    }
                    else
                    {
                        output[i] = number;
                        i++;
                    }
                }
                return output;
            }
        }
    }
