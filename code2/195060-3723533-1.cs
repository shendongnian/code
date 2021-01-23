    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1 {
        class Program{
            static void Main(string[] args){
                String[] parts = "str1||str2|str3".Replace(@"||", "|\"blank\"|").Split(@"|");
                foreach (string s in parts)
                    Console.WriteLine(s);
            }
        }
    }
