    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Test
    {
        public static void Main()
        {
            var xdoc = XDocument.Load("test.xml");
            XName brName = "break";
            XName psfName = "psf";
            
            var invalidNames = 
                from h1 in xdoc.Descendants("h1")
                // Find the last sibling element before the h1
                let previous = h1.ElementsBeforeSelf().LastOrDefault()
                // It's invalid if there isn't a previous element, or it has
                // a name other than break or psf
                where previous?.Name != brName && previous?.Name != psfName
                // Get the name to report, handling the case where there's
                // no previous break or no "name" attribute
                select ((string) h1.ElementsBeforeSelf(brName).LastOrDefault()?.Attribute("name")) ?? "(no named break)";
        
            Console.WriteLine(string.Join(", ", invalidNames));
        }
    }
