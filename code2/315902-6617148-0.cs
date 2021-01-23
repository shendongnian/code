    using System;
    using System.Text.RegularExpressions;
    
    class MyClass
    {
       static void Main(string[] args)
       {
          var input = "a 1.4 b 10";
    
          Regex r = new Regex(@"[+-]?\d[\d\.]*"); // can be improved
    		
          Console.WriteLine(input);
          Console.WriteLine(r.Replace(input, new MatchEvaluator(ReplaceCC)));
       }
    
       public static string ReplaceCC(Match m)
       {
           return (Double.Parse(m.Value) * 1.14).ToString();
       }
    }
    [mono] ~ @ mono ./t.exe
    a 1.4 b 10
    a 1.596 b 11.4
