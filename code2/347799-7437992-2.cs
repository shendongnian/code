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
                public List<string> FileNames { get; set; }
                public DataBaseRecord(string _PartNumber, List<string> _FileNames)
                {
                    PartNumber = _PartNumber;
                    FileNames = _FileNames;
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
    
                    bool exists = records.Count(x => x.PartNumber == partNumber) > 0;
                    if (!exists)
                    {
                        records.Add(new DataBaseRecord(partNumber, new List<string>() { fileName }));
                    }
                    else
                    {
                        var record = from x in records where x.PartNumber == partNumber select x;
                        foreach (DataBaseRecord dbr in record)
                        {
                            exists = dbr.FileNames.Count(x => x == fileName) > 0;
                            if (!exists)
                                dbr.FileNames.Add(fileName);
                        }
                    }
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
                            if (partNumber[0] == '\"')
                                partNumber = partNumber.Substring(1, partNumber.Length - 2);
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
                            for (int index = 0; index < record.FileNames.Count; index++)
                            {
                                line += record.FileNames[index];
                                if (index < record.FileNames.Count - 1)
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
                DataBase db = new DataBase(@"C:\Users\jondoe\Desktop\DataBase.txt");
                db.Read();
    
                // replace with list of your parts files
                string[] partsFiles = new string[] { @"C:\Users\jondoe\Desktop\parts.txt" };
                foreach (string partsFile in partsFiles)
                {
                    using (StreamReader sr = new StreamReader(partsFile))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string partNumber = line.Split(new string[] { "," }, StringSplitOptions.None)[7];
                            if (partNumber[0] == '\"')
                                partNumber = partNumber.Substring(1, partNumber.Length - 2);
                            db.AddRecord(partNumber, Path.GetFileNameWithoutExtension(partsFile));
                        }
                    }                
                }
    
                db.Write();
            }
        }
    }
