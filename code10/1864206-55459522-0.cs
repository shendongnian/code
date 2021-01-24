    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication107
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = {
                                      "libgcc1-5.2.0-r0.70413e92.rbt.xar",
                                      "python3-sqlite3-3.4.3-r1.0.f25d9e76.rbt.xar",
                                      "u-boot-signed-pad.bin-v2015.10+gitAUTOINC+1b6aee73e6-r0.02df1c57.rbt.xar"
                                  };
                string pattern = @"(?'prefix'.+)-(?'middle'[^-][\w+\.]+-[\w+\.]+)\.(?'extension'[^\.]+).\.xar";
                foreach (string input in inputs)
                {
                    Match match = Regex.Match(input, pattern, RegexOptions.RightToLeft);
                    Console.WriteLine("prefix : '{0}', middle : '{1}', extension : '{2}'",
                        match.Groups["prefix"].Value,
                        match.Groups["middle"].Value,
                        match.Groups["extension"].Value
                        );
                }
                Console.ReadLine();
            }
        }
    }
