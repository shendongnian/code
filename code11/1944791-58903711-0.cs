    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace FileToListInt
    {
        class Program
        {
            static readonly string filePath = "randomNumbers.txt";
    
            static string Delimiter => " ";
            static string LineBreak => "\r\n";
                
            static void WriteTestFile(string fileName,
                int dataLength = 100000,
                int dataMinvalue = 1,
                int dataMaxValue = 250,
                int lineBreakPosition = 25)
            {
                int iterator = 0;
                string delimiter;
    
                Random rndGenerator = new Random();
                int randomNumber;
    
                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    while (iterator < dataLength)
                    {
                        randomNumber = rndGenerator.Next(dataMinvalue, dataMaxValue);
                        delimiter = ++iterator % lineBreakPosition == 0 ? LineBreak : Delimiter;
                        streamWriter.Write($"{randomNumber}{delimiter}");
                    }
                }
            }
    
            static List<int> ReadTestFile(string fileName)
            {
                string fileContents;
    
                using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                using (var streamReader = new StreamReader(fileStream))
                {
                    fileContents = streamReader.ReadToEnd();
                }
    
                var separators = string.Join("", LineBreak, Delimiter).ToCharArray();
                var query = from item in fileContents
                             .Split(separators, StringSplitOptions.RemoveEmptyEntries)                        
                             select int.Parse(item);
    
                return query.ToList();
            }
    
            static void Main(string[] args)
            {
                // Writing data to a test file
                WriteTestFile(filePath);
    
                // Reading result into a List<int>
                List<int> data = ReadTestFile(filePath);
    
                // Checking the number of readings
                Console.WriteLine(data.Count);
    
                // Deleting test file
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
        }
    }
