    using System;
    namespace Doubletesting
    {
        class Program
        {
            static void Main(string[] args)
            {
                double d = Doubletesting.TestDouble(3.5);
    
                Console.WriteLine(d.ToString());
    
                Console.ReadKey();
            }
    
            public static double TestDouble(double x)
            {
                double result;
    
                result = x;
    
                return result;
            }
        }
    }
