    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="3Z 5Z";
    
          string re1="(\\d+)";	// Integer Number 1
          string re2="(Z)";	// Any Single Character 1
          string re3="( )";	// Any Single Character 2
          string re4="(\\d+)";	// Integer Number 2
          string re5="(Z)";	// Any Single Character 3
    
          Regex r = new Regex(re1+re2+re3+re4+re5,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String int1=m.Groups[1].ToString();
                String c1=m.Groups[2].ToString();
                String c2=m.Groups[3].ToString();
                String int2=m.Groups[4].ToString();
                String c3=m.Groups[5].ToString();
                Console.Write("("+int1.ToString()+")"+"("+c1.ToString()+")"+"("+c2.ToString()+")"+"("+int2.ToString()+")"+"("+c3.ToString()+")"+"\n");
          }
          Console.ReadLine();
        }
      }
    }
