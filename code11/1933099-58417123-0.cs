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
                List<KeyValuePair<string, decimal>> data = new List<KeyValuePair<string,decimal>>();
                int lineNumber = 0;
                while((line = reader.ReadLine()) != null)
                {
                    if(++lineNumber > 1)
                    {
                        string key = line.Substring(0, 50).Trim();
                        decimal value = decimal.Parse(line.Substring(50));
                        data.Add(new KeyValuePair<string,decimal>(key,value));
                    }
                }
            }
        }
     
    }
