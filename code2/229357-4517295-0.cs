        using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="http://www.google.com";
    
          string re1="((?:http|https)(?::\\/{2}[\\w]+)(?:[\\/|\\.]?)(?:[^\\s\"]*))";	// HTTP URL 1
    
          Regex r = new Regex(re1,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String httpurl1=m.Groups[1].ToString();
                Console.Write("("+httpurl1.ToString()+")"+"\n");
          }
          Console.ReadLine();
        }
      }
    }
