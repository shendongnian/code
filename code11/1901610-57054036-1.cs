    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication120
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<Dictionary<string, string>> items = new List<Dictionary<string, string>>();
                XmlReader reader = XmlReader.Create(FILENAME);
                reader.ReadToFollowing("hugeArray");
                while (!reader.EOF)
                {
                    if (reader.Name != "item")
                    {
                        reader.ReadToFollowing("item");
                    }
                    if (!reader.EOF)
                    {
                        XElement item = (XElement)XElement.ReadFrom(reader);
                        Dictionary<string, string> dict = item.Elements()
                            .GroupBy(x => x.Name.LocalName, y => (string)y)
                            .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                        items.Add(dict);
                    }
                }
            }
        }
    }
