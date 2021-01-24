    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.txt";
            const string OUTPUT_FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string header = "<xmlnodes></xmlnodes>";
                XDocument doc = XDocument.Parse(header);
                XElement xmlnodes = doc.Root;
                StreamReader reader = new StreamReader(INPUT_FILENAME);
                string line = "";
                string[] columnNames = null;
                int lineCount = 0;
                while((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        string[] splitArray = line.Split(new char[] { '\t', ' '}, StringSplitOptions.RemoveEmptyEntries);
                        if (++lineCount == 1)
                        {
                            columnNames = splitArray;
                        }
                        else
                        {
                            XElement newNode = new XElement("xmlnode");
                            xmlnodes.Add(newNode);
                            for(int i = 0; i < splitArray.Length; i++)
                            {
                                XElement xColumn = new XElement(columnNames[i], splitArray[i]);
                                newNode.Add(xColumn);
                            }
                        }
                    }
                }
                doc.Save(OUTPUT_FILENAME);
            }
     
        }
     
    }
