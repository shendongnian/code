    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace AscendingSequences
    {
        class AscendingSequences
        {
            const string FILENAME = @"c:\temp\test.xml";
            public static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<int, Dictionary<string, string>> dict = doc.Descendants("TestDriveRequest")
                    .GroupBy(x => (int)x.Attribute("Record"), y => y.Elements("element")
                        .GroupBy(a => (string)a.Attribute("name"), b => (string)b)
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                        .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
