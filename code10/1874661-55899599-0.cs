    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main()
        {
            var input = XDocument.Load("test.xml");
            XNamespace ncx = "http://www.daisy.org/z3986/2005/ncx/";
            XNamespace xhtml = "http://www.w3.org/1999/xhtml";
            // Skipped creating all the rest of the structure: focusing on the
            // navMap
            var navMap = new XElement(ncx + "navMap");
            var inhalt = input.Descendants(xhtml + "div")
                .Single(div => (string) div.Attribute("id") == "Inhalt");
            
            XElement currentTop = null;
            XElement currentChild = null;
            
            int index = 1;
            foreach (var element in inhalt.Elements())
            {
                string id = $"navPoint-{index++:00}";
                var point = new XElement(ncx + "navPoint", new XAttribute("id", id));
                var navLabel = new XElement(ncx + "navLabel", element.Value);
                point.Add(navLabel);
                // TODO: playOrder attribute, text element etc. They're not important for nesting.
                switch (element.Attribute("class")?.Value)
                {
                    case "toc-ch":
                        currentTop = point;
                        currentChild = null;
                        navMap.Add(point);
                        break;
                    case "toc-h1":
                        if (currentTop == null)
                        {
                            throw new InvalidOperationException("toc-h1 with no toc-ch");
                        }
                        currentChild = point;
                        currentTop.Add(point);
                        break;
                    case "toc-h2":
                        if (currentChild == null)
                        {
                            throw new InvalidOperationException("toc-h2 with no toc-h1");
                        }
                        currentChild.Add(point);
                        break;
                    default:
                        throw new InvalidOperationException("Unknown class attribute");
                }
            }
            
            var output = new XDocument(new XElement(ncx + "ncx", navMap));
            var settings = new XmlWriterSettings { Indent = true };
            using (var writer = XmlWriter.Create(Console.Out, settings))
            {
                output.Save(writer);
            }
        }
    }
