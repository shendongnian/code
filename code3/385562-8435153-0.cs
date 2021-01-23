    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Sample {
        static string Frame(int width, int height){
            var wk = new List<string>();
            string term = new String('*', width);
            string inner = "*" + new String(' ', width-2) + "*";
            wk.Add(term);
            wk.AddRange(Enumerable.Repeat(inner, height-2));
            wk.Add(term);
            return String.Join("\n", wk);
            
        }
        static void Main(){
            string s = Frame (5, 4);
            Console.WriteLine (s);
        }
    }
    
