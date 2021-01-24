    using System;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication9
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                TestModel model = new TestModel(FILENAME);
            }
        }
        public class TestModel
        {
            public List<Item> items { get; set; }
            public TestModel(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                items = doc.Descendants("ITEM").Select(x => new Item()
                {
                    Title = ((string)x.Element("TITLE")).Trim(),
                    Description = string.Join(",", x.Element("DESCRIPTION")
                       .Elements("P").Select(y => (string)y)),
                    MoreInfo = string.Join(",", x.Element("MOREINFO")
                       .Elements("P").Select(y => (string)y))
                }).ToList();
            }
     
        }
        public class Item
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string MoreInfo { get; set; }
        }
    }
