    using System;
    class Test
    {
        static double Compute(double x)
        {
            return -1E-06 * Math.Pow(x, 6) 
                + 0.0001 * Math.Pow(x, 5) 
                - 0.0025 * Math.Pow(x, 4) 
                + 0.0179 * Math.Pow(x, 3) 
                + 0.0924 * Math.Pow(x, 2)
                - 0.6204 * x + 55.07;
        }
        static void Main()
        {
            Console.WriteLine("Value for x {0} == {1}", 5, Compute(5));
            Console.ReadKey();
        }
    }
