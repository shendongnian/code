    using System;
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.MaxValue;
            int b = int.MinValue;
            try
            {
                checked
                {
                    int m = a * b;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("over flow exception");
                Console.Read();
            }
        }
    }
