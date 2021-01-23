    using System;
    
    namespace CMYKConversion
    {
        class Program
        {
            static void Main(string[] args)
            {
                Converter c = new Converter();
                c.Convert();
    
                Console.ReadKey();
            }
        }
    }
