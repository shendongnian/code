    using System;
    using System.Xml.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var xml = @"<?xml version=""1.0""?>
                            <catalog>
                               <book id=""bk101"">
                                  <author>Gambardella, Matthew</author>
                                  <title>XML Developer's Guide</title>
                                  <genre>Computer</genre>
                                  <price>44.95</price>
                                  <publish_date>2000-10-01</publish_date>
                                  <description>An in-depth look at creating applications 
                                  with XML.</description>
                               </book>
                            </catalog>";
            XElement e = XElement.Parse(xml);
            var books = e.Elements("book");
            foreach (var book in books)
            {
                var title = book.Element("title").Value;
                var author = book.Element("author").Value;
                var isbn = book.Attribute("id").Value;
                Console.WriteLine("{0} ({1}) is written by {2}", title, isbn, author);
            }
        }
    }
