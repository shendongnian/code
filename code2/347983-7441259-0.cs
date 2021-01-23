        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] bytes = { 49, 46, 48, 50 };
                //get string
                string str = new string(Encoding.ASCII.GetChars(bytes));
                Console.WriteLine(str);
    
                //get number
                double d;
                if (double.TryParse(str, out d))
                {
                    Console.WriteLine(d);
                }
    
            }
        }
    }
