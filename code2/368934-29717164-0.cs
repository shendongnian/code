    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"C:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                List<List<int>> data = new List<List<int>>();
                while ((inputLine = reader.ReadLine()) != null)
                {
                    string[] inputArray = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (inputArray.Count() > 0)
                    {
                        List<int> numbers = inputArray.Select(x => int.Parse(x)).ToList();
                        data.Add(numbers);
                    }
                }
               
            }
            
        }
    }
    ​
