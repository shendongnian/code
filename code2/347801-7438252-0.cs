    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        public class FileIo
        {
            private Dictionary<int, CommaDelimitedStringCollection> dataBase;
            private const string DATABASE_PATH = @"D:\Temp\Test\DATABASE.txt";
    
    
            public void Run()
            {
                dataBase = GetDatabase();
    
                var files = new List<string> { @"D:\Temp\Test\Test1.txt", @"D:\Temp\Test\Test2.txt", @"D:\Temp\Test\Test3.txt" };
    
                foreach (var file in files)
                {
                    Search(file, GetPartNumbers(file));  
                }
    
                WriteFileContents(DATABASE_PATH, BuildPartsDbStr());
            }
    
            private void Search(string fileName, List<int> partNums)
            {
                foreach (var partNum in partNums)
                {
                    var path = Path.GetFileNameWithoutExtension(fileName);
                    if (dataBase.Keys.Contains(partNum))
                    {
                        dataBase[partNum].Add(path);
                    }
                    else
                    {
                        dataBase.Add(partNum, new CommaDelimitedStringCollection { path });
                    }
    
                   
                }
            }
    
            private string BuildPartsDbStr()
            {
                var sb = new StringBuilder();
    
                var db  = from x in dataBase orderby x.Key select x;
                foreach (var record in db)
                {
                    sb.Append(string.Format("{0}: {1}{2}", record.Key, record.Value, Environment.NewLine));
                }
    
                return sb.ToString();
            }
    
            private Dictionary<int, CommaDelimitedStringCollection> GetDatabase()
            {
                var contents = GetFileContents(DATABASE_PATH);
                var commaStr = new CommaDelimitedStringCollection();
                
                commaStr.AddRange(contents.Split(','));
                var db = new Dictionary<int, CommaDelimitedStringCollection>();
    
                var id = 0;
                var collection = new CommaDelimitedStringCollection();
                for (var i = 0; i < commaStr.Count; i++ )
                {
                    var str = commaStr[i];
                    if (str.Contains(":"))
                    {
                        collection.Add(str.Split(':')[1]);
                        if (i > 0) db.Add(id, collection);
                        collection = new CommaDelimitedStringCollection();
                        id = int.Parse(str.Split(':')[0]);
                    }
                    else
                    {
                        collection.Add(str);
                    }
                }
    
                return db;
            }
            
            private List<int> GetPartNumbers(string filePath)
            {
                var contents = GetFileContents(filePath);
                var commaStr = new CommaDelimitedStringCollection();
                commaStr.AddRange(contents.Split(','));
    
                var result = new List<int>();
                for(var i = 7; i < commaStr.Count; i += 15)
                {
                    result.Add(int.Parse(commaStr[i].Replace("\"", string.Empty)));
                }
    
                return result;
            } 
    
    
            private string GetFileContents(string path)
            {
                using (var stream = new StreamReader(path))
                {
                    return stream.ReadToEnd();
                }
            }
    
            private void WriteFileContents(string path, string contents)
            {
                using (var stream = new StreamWriter(path, false))
                {
                    stream.Write(contents);
                }
            }
    
        }
    }
