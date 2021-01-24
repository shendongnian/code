    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> records = doc.Descendants("record").ToList();
                List<string> uniquetagNames = records.SelectMany(x => x.Elements().Select(y => y.Name.LocalName)).Distinct().ToList();
                foreach (XElement record in records)
                {
                    XElement newRecord = new XElement("record");
                    foreach (string uniquetagName in uniquetagNames)
                    {
                        if (record.Element(uniquetagName) == null)
                        {
                            newRecord.Add(new XElement(uniquetagName));
                        }
                        else
                        {
                            newRecord.Add(record.Element(uniquetagName));
                        }
                    }
                    record.ReplaceWith(newRecord);
                }
            }
        }
    }
