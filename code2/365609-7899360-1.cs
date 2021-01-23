    using System;
    
    class Test
    {    
        static void Main(string[] args)
        {
            string x = "hello";
            string y = new string(x.ToCharArray());        
            Console.WriteLine(x == y); // True
            
            object ox = x;
            object oy = y;
            Console.WriteLine(ox == oy); // False
    
            dynamic dx = x;
            dynamic dy = y;
            Console.WriteLine(dx == dy); // True
        }
    }
