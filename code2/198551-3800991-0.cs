    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                for (int i = 0; i < 40; ++i) {
                    string s = Ellipsis("Lorem ipsum dolor sit amet, amet consectetur adipiscing elit.", i);
                    Console.WriteLine("{0} : {1}", i, s);
                }
            }
    
            static public string Ellipsis(string text, int length) {
                if (text.Length <= length) return text;
                int pos = text.IndexOf(" ", length) ;
                return text.Substring(0, pos >= 0 ? pos : 0) + "..."; 
            }
        }
    }
