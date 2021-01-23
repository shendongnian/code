    using System;
    namespace DumpMatrix
    {
        class Program
        {
            static void Main(string[] args)
            {
                var matrix = new int[10, 15];
                var rand = new Random();
                for(int m=0; m<matrix.GetLength(0); ++m)
                {
                    for(int n=0; n<matrix.GetLength(1); ++n)
                    {
                        matrix[m, n] = rand.Next(100);
                    }
                }
                for (int m = 0; m < matrix.GetLength(0); ++m)
                {
                    for (int n = 0; n < matrix.GetLength(1); ++n)
                    {
                        Console.Write("{0,3} ", matrix[m, n]);
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
    }
