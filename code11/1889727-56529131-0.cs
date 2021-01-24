    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] SampleInputList = new string[]
                {
                    "type:EXAMPLE",
                    " type: EXAMPLE ",
                    "   type:  EXAMPLE  "
                };
    
                // The following is a non-capture group indicator: (?:)
                // non-capture groups are a good way to organize parts
                // of your regex string and can help you visualize the
                // parts that are just markers like 'type:' vs. the parts
                // that you want to actually manipulate in the code.
                Regex expression = new Regex(@"(?:\s*type\:\s*)([A-Za-z]*)");
    
                foreach (string Sample in SampleInputList)
                {
                    MatchCollection matches = expression.Matches(Sample);
                    if (matches.Count > 0)
                    {
                        GroupCollection groups = matches[0].Groups;
                        if (groups.Count > 1)
                        {
                            Console.WriteLine(groups[1].Value);
                        }
                    }
                }
            }
        }
    }
