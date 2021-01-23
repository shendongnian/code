    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
            public static void Main()
            {
                    Regex r = new Regex(@"(\r[^\n])|([^\r]\n)");
                    string[] Test = { "Hello,\r\n\r\nWelcome on board of our brand-new cruise line.\r\nKind regards", 
                                             "Hello\r\r\nWelcom on board of our brand-new cruise line.\nKind regards" };
     
                    foreach(string t in Test)
                    {
                            System.Console.Write("\"{0}\" ", t.Replace("\r", "\\r").Replace("\n", "\\n"));
                            if(r.IsMatch(t))
                                    System.Console.WriteLine("Is not ok");
                            else
                                    System.Console.WriteLine("Is ok");
                    }
            }
    }
