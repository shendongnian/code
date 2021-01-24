    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication108
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                string category = "";
                string pattern = @"(?'name'.*)\s+(?'price'\d+)";
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        if (line.StartsWith("#"))
                        {
                            category = line.Substring(1);
                        }
                        else
                        {
                            Match match = Regex.Match(line, pattern);
                            string name = match.Groups["name"].Value.Trim();
                            string price = match.Groups["price"].Value.Trim();
                            Console.WriteLine("category : '{0}', name : '{1}', price : '{2}'", category, name, price);
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
