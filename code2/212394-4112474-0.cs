    using System;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            StringBuilder builder = new StringBuilder("5002");
            builder[1] = '3';
            Console.WriteLine(builder); // Prints 5302
        }
    }
