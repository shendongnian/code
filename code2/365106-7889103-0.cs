    using System;
    using System.Text.RegularExpressions;
    
    class Sample {
    //  delegate string MatchEvaluator (Match match);
        static public void Main(){
    
            string str = "<CustomAction Id=<newGuid> /><CustomAction Id=<newGuid> />";
            MatchEvaluator myEvaluator = new MatchEvaluator(m => newValueFunc());
            Regex regex = new Regex("newGuid");//OldValue
            string newStr = regex.Replace(str, myEvaluator);
            Console.WriteLine(newStr);
        }
        public static string newValueFunc(){
            return "NewGuid";
        }
    }
