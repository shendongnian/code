    using System;
    
    class Program
    {
    
        static void Main(string[] args)
        {
            DateTime dt;
            Console.WriteLine(DateTime.TryParse(1.0228, out dt));
        }
    }
