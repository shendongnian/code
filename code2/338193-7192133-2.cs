    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
            public static void Main()
            {
    		Regex rxSingleCharNewLine = new Regex(@"\r(?!\n)|(?<!\r)\n",RegexOptions.Singleline);
    		Regex rxNewLine = new Regex(@"\r\n",RegexOptions.Singleline);
                    string[] Test = { "Hello,\r\n\r\nWelcome on board of our brand-new cruise line.\r\nKind regards", 
                                             "Hello\r\r\nWelcom on board of our brand-new cruise line.\nKind regards" };
    
                    foreach(string t in Test)
                    {
                            System.Console.Write("\"{0}\" ", t.Replace("\r", "\\r").Replace("\n", "\\n"));
                            if(!rxSingleCharNewLine.IsMatch(t) && rxNewLine.IsMatch(t))
                                    System.Console.WriteLine("Is ok");
                            else
                                    System.Console.WriteLine("Is not ok");
                    }
            }
    }
