    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FOLDER = @"c:\temp\";
            const string CSV_FILENAME = @"c:\temp\test.csv";
             static void Main(string[] args)
             {
                string[] xmlFiles = Directory.GetFiles(FOLDER, "*.xml");
                StreamWriter writer = new StreamWriter(CSV_FILENAME);
                Boolean firstLine = true;
                for (int idx = 0; idx < xmlFiles.Length; idx++)
                {
                    string file_name = xmlFiles[idx]; 
                    XDocument doc  = XDocument.Load(file_name);
                    foreach(XElement data in doc.Descendants("Data"))
                    {
                        if (firstLine)
                        {
                            string[] headers = data.Elements().Select(x => x.Name.LocalName).ToArray();
                            writer.WriteLine(string.Join(",", headers));
                            firstLine = false;
                        }
                        string[] row = data.Elements().Select(x => (string)x).ToArray();
                        writer.WriteLine(string.Join(",", row));
                    }
                }
                writer.Flush();
                writer.Close();
            }
        }
      
    }
