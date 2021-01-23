    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            string x = null;
            string y = "y";
            string z = "z";
            
            Console.WriteLine(x ?? y ?? z); // Prints "y"
        }
    }
