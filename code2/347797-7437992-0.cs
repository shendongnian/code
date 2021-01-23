    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private class DataBaseRecord
            {
                public string PartNumber { get; set; }
                public List<string> FileNumbers { get; set; }
                public DataBaseRecord(string _PartNumber, List<string> _FileNumbers)
                {
                    PartNumber = _PartNumber;
                    FileNumbers = _FileNumbers;
                }
            }
    
            private class DataBase
            {
                public string databaseFile { get; set; }
                List<DataBaseRecord> records;
                public DataBase(string _databaseFile)
                {
                    databaseFile = _databaseFile;
                    records = new List<DataBaseRecord>();
                }
                public void AddRecord(string partNumber, string fileName)
                {
                    if (string.IsNullOrWhiteSpace(partNumber))
                        return;
    
                    if (string.IsNullOrWhiteSpace(fileName))
                        return;
    
                    // must implement add record here - account for duplicates etc..                
    
                }
                public void Read()
                {
                    // read all database records into data structure
                    using (StreamReader sr = new StreamReader(databaseFile))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string partNumber = line.Split(':')[0].Trim();
                            string[] files = line.Split(new string[]{":"}, StringSplitOptions.None)[1].Split(new string[]{","}, StringSplitOptions.RemoveEmptyEntries);
                            List<string> fileNumbers = new List<string>();
                            foreach (String file in files)
                            {
                                if (!string.IsNullOrWhiteSpace(file))
                                {
                                    fileNumbers.Add(file.Trim());
                                }
                            }
                            records.Add(new DataBaseRecord(partNumber, fileNumbers));
                        }
                    }
                }
                public void Write()
                {
                    // write out database using the records
                    var sortedRecords = from x in records orderby x.PartNumber select x;
                    using (StreamWriter sw = new StreamWriter(databaseFile))
                    {
                        foreach (DataBaseRecord record in sortedRecords)
                        {
                            string line = record.PartNumber + ": ";
                            for (int index = 0; index < record.FileNumbers.Count; index++)
                            {
                                line += record.FileNumbers[index];
                                if (index < record.FileNumbers.Count - 1)
                                    line += ", ";
                            }
                            sw.WriteLine(line);
                        }
                    }
                }
            }
    
            static void Main(string[] args)
            {
                // replace with name of your database
                DataBase db = new DataBase(@"C:\Users\JonDoe\Desktop\DataBase.txt");
                db.Read();
    
                // replace with list of your parts files
                string[] partsFiles = new string[] { @"C:\Users\JonDoe\Desktop\125663-D2.txt", @"C:\Users\JonDoe\Desktop\187563-A2.txt" };
                foreach (string partsFile in partsFiles)
                {
                    using (StreamReader sr = new StreamReader(partsFile))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string partNumber = line.Split(new string[] { "," }, StringSplitOptions.None)[7];
                            db.AddRecord(partNumber, Path.GetFileNameWithoutExtension(partsFile));
                        }
                    }                
                }
    
                db.Write();
            }
        }
    }
