    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var expression = @"select * from mytable where projectname = __$ProjectName$__ and  projectid = __$ProjectId$__ and env = __$EnvType$__";
    
                var output = new Regex(@"__\$[^\s]+?\$__")
                    .Matches(expression)
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToList();
    
                output.ForEach(Console.WriteLine);
            }
        }
    }
