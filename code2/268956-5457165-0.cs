    using System;
    
    [assembly: CLSCompliant(true)]
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static int Test(int val=42)
            {
                return val;
            }
    
            static void Main(string[] args)
            {
                System.Console.WriteLine(Test());
            }
        }
    }
