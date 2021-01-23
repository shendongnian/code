    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="Shankar[admin@contentraven.com]";
    
          string re1="((?:[a-z][a-z0-9_]*))";	// Variable Name 1
    
          Regex r = new Regex(re1,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String var1=m.Groups[1].ToString();
                Console.Write(var1.ToString()+"\n");
          }
          Console.ReadLine();
        }
      }
    }
