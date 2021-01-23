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
                string html = "<li>123</li><li>456</li>";
                string[] sep = {"</li>"};
                foreach (string s in html.Replace("<li>","").Split(sep, StringSplitOptions.None)) 
                    Console.WriteLine(s);
                Console.ReadLine();
            }
        }
    }
