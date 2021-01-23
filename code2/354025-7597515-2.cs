    using System;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                String matchParenthesis = @" 
                    (?# line 01) \((
                    (?# line 02) (?> 
                    (?# line 03) \( (?<DEPTH>) 
                    (?# line 04) | 
                    (?# line 05) \) (?<-DEPTH>) 
                    (?# line 06) | 
                    (?# line 07) .? 
                    (?# line 08) )* 
                    (?# line 09) (?(DEPTH)(?!)) 
                    (?# line 10) )\) 
                    ";
                
                //string source = "if (2 > 1) then ( if(3>2) then ( if(4>3) then 4 else 3 endif ) else 2 endif) else 1 endif"; 
                string source = "if (2 > 1) then 2 else ( if(3>2) then ( if(4>3) then 4 else 3 endif ) else 2 endif) endif";
                string pattern = @"if\s*(?<condition>(?:[^(]*|" + matchParenthesis + @"))\s*";
                pattern += @"then\s*(?<then_part>(?:[^(]*|" + matchParenthesis + @"))\s*";
                pattern += @"else\s*(?<else_part>(?:[^(]*|" + matchParenthesis + @"))\s*endif";
                Match match = Regex.Match(source, pattern, 
                        RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase); 
                Console.WriteLine(match.Success.ToString()); 
                Console.WriteLine("source: " + source ); 
                Console.WriteLine("condition = " + match.Groups["condition"]); 
                Console.WriteLine("then part = " + match.Groups["then_part"]); 
                Console.WriteLine("else part = " + match.Groups["else_part"]); 
            }
        }
    }
