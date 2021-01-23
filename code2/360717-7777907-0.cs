    using System;
    using System.Text.RegularExpressions;
    class Sample {
        public static void Main(){
            var str = "((100&12)%41)&(43&144)";
            var pat = "([()&%])";
            var tokens = Regex.Split(str,pat);
            foreach(var token in tokens){
                if( !string.IsNullOrEmpty(token))
                    Console.WriteLine("{0}", token);
            }
        }
    }
