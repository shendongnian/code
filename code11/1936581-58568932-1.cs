    using System;
    using System.Linq;
    
    namespace MathReturns0
    {
        class Program
        {
            static void Main(string[] args)
            {
                var temp = 18801010019;
                var A = (temp / (long)(Math.Pow(10, 10)) % 10);
                var B = (temp / (long)(Math.Pow(10, 9)) % 10);
                var C = (temp / (long)(Math.Pow(10, 8)) % 10);
                var D = (temp / (long)(Math.Pow(10, 7)) % 10);
                var E = (temp / (long)(Math.Pow(10, 6)) % 10);
                var F = (temp / (long)(Math.Pow(10, 5)) % 10);
                var G = (temp / (long)(Math.Pow(10, 4)) % 10);
                var H = (temp / (long)(Math.Pow(10, 3)) % 10);
                var I = (temp / (long)(Math.Pow(10, 2)) % 10);
                var J = (temp / (long)(Math.Pow(10, 1)) % 10);
                var K = (temp / (long)(Math.Pow(10, 0)) % 10);
                var S = (A * 1) + (B * 2) + (C * 3) + (D * 4) + (E * 5) + (F * 6) + (G * 7) + (H * 8) + (I * 9) + (J * 10) + (K * 11);
    
                Console.WriteLine("S has the value {0}.", S);
    
                Console.WriteLine("AddDigits has the value {0}.", AddDigits(temp));
    
                Console.WriteLine("AddDigits has the value {0}.", AddDigits2(temp));
            }
    
            static int AddDigits(long val)
            {
                var multiplier = Convert.ToInt32(Math.Ceiling(Math.Log10(val)));
                var output = 0;
                while (val > 0)
                {
                    output += multiplier * Convert.ToInt32(val % 10);
                    multiplier--;
                    val /= 10;
                }
                return output;
            }
    
            static int AddDigits2(long val)
            {
                return val.ToString().ToList().Select((x, i) => int.Parse(x.ToString()) * (i+1)).Sum();
            }
    
        }
    }
