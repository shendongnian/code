    using System;
    
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("number to check");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("1st range");
            int rang1 = int.Parse(Console.ReadLine());
            Console.WriteLine("2n range:");
            int rang2 = int.Parse(Console.ReadLine());
            if (EnRang(a, rang1, rang2) == true)
            {
                Console.WriteLine("Number {0} is between {1} and {2}", a, rang1, rang2);
            }
            else if (EnRang(a, rang1, rang2) == false)
            {
                Console.WriteLine("The number {0} isn't between {1} and {2}", a, rang1, rang2);
            }
            else
            {
                Console.WriteLine("Something goes wrong.");
            }
        }
    
        public static bool EnRang(int NumerBool, int RangA, int RangB)
        {
    
            if (NumerBool > RangA || NumerBool < RangB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
