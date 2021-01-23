    using System;
    using W3b.Sine;
    
    namespace summation
    {
        public class Program
        {
            static BigNum doSummation(int maxPower)
            {
                BigNum sum = 0;
                for (int i = 1; i <= maxPower; i++)
                {
                    sum += Math.Pow(2, i * -1);
                }
                return sum;
            }
            static void Main(string[] args)
            {
              Console.WriteLine(doSummation(100));
            }
        }
    }
