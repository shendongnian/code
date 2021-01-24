    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication147
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test1.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                Dictionary<string, List<List<string>>> dict = new Dictionary<string, List<List<string>>>();
                string line = "";
                while((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        string[] splitData = line.Split(new char[] { '|' }).ToArray();
                        if (dict.ContainsKey(splitData[0]))
                        {
                            dict[splitData[0]].Add(splitData.Skip(1).ToList());
                        }
                        else
                        {
                            dict.Add(splitData[0], new List<List<string>>() {splitData.Skip(1).ToList()});
                        }
                    }
                }
                foreach (List<String> code in dict["5270"])
                {
                    Console.WriteLine("Product Code : {0}; Code : '{1}'; Data : '{2}'","5270", code[2], string.Join(",", code));
                }
                Console.ReadLine();
            }
        }
    }
