    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                while((line = reader.ReadLine()) != null)
                {
                    if(line.StartsWith("start"))
                    {
                        string[] splitArray = line.Split(new char[] { ' ' }).ToArray();
                        Console.WriteLine(splitArray[1]);
                    }
                }
                Console.ReadLine();
            }
        }
    }
