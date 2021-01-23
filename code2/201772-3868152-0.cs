    using System;
    
    class Program
    {
        static void Main()
        {
            // Example bool is true
            bool t = true;
    
            // A
            // Convert bool to int
            int i = t ? 1 : 0;
            Console.WriteLine(i); // 1
    
            // Example bool is false
            bool f = false;
    
            // B
            // Convert bool to int
            int y = Convert.ToInt32(f);
            Console.WriteLine(y); // 0
        }
    }
