    using System;
    
    enum Color { Red, Green, Blue }
    
    class Test
    {
        static void Main()
        {
            Color c = Color.Blue;
            object o = c;        
            int i = (int) o;
            Console.WriteLine(i); // Prints 2
            
            i = 1;
            o = i;
            c = (Color) o;
            Console.WriteLine(c); // Prints Green
        }
    }
