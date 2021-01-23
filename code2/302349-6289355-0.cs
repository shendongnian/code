    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
    
            var result = 
                (from cd in doc.Root.Descendants("cd")
                 let artist = cd.Element("artist")
                 let title = cd.Element("title")
                 where artist != null && title != null && artist.Value == "Pink Floyd"
                 select title.Value
                ).FirstOrDefault();
            Console.WriteLine(result);
        }
    }
