        using System;
        namespace TestTSql
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Console.WriteLine(TSqlRound(150.757, 2, false));    // 150.76
                    Console.WriteLine(TSqlRound(150.757, 2, true));     // 150.75
                    Console.WriteLine(TSqlRound(150.747, 2, false));    // 150.75
                    Console.WriteLine(TSqlRound(150.747, 2, true));     // 150.74
                    Console.ReadKey();
                }
                public static double TSqlRound(double input, int length, bool truncate = false)
                {
                    if (truncate)
                    {
                        double factor = Math.Pow(10, length);
                        return Math.Truncate(input * factor) / factor;
                    }
                    else return Math.Round(input, length);
                }
            }
        }
