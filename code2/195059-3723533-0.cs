    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1 {
        class Program{
            static void Main(string[] args){
                String data = "str1||str2|str3".Replace(@"||", "|\"blank\"|");
                String[] parts = new Regex("[|]+").Split(data);
                foreach (string s in parts)
                    Console.WriteLine(s);
            }
        }
    }
