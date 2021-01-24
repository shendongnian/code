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
                List<Item> items = new List<Item>();
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
                        Item newItem = new Item()
                        {
                            companyId = (string)item.Element("companyId"),
                            direction = (string)item.Element("direction"),
                            nameId = (string)item.Element("nameId")
                        };
                        items.Add(newItem);
                    }
                }
            }
        }
        public class Item
        {
            public string direction { get;set;}
            public string companyId { get;set;}
            public string nameId { get; set; }
        }
    }
