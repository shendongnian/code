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
                List<BookItem> bookitems = doc.Descendants("book").Select(x => new BookItem() {
                    Id = (string)x.Attribute("id"),
                    Author = (string)x.Element("author"),
                    Title = (string)x.Element("title"),
                    Genre = (string)x.Element("genre"),
                    Price = (decimal)x.Element("price"),
                    Publish_date = (DateTime)x.Element("publish_date"),
                    Description = (string)x.Element("description")
                }).ToList();
                
            }
        }
        public class BookItem
        {
            public string Id { get; set; }
            public string Author { get; set; }
            public string Title { get; set; }
            public string Genre { get; set; }
            public decimal Price { get; set; }
            public DateTime Publish_date { get; set; }
            public string Description { get; set; }
        }
    }
