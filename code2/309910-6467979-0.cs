    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace XML_Merge {
        class Program {
            static void Main(string[] args) {
    
                // load two xdocs
                var x1 = XDocument.Load("x1.xml");
                var x2 = XDocument.Load("x2.xml");
    
                // select the CLASS nodes from each
                var c1 = x1.Descendants("AC").First().Descendants("CLASS");
                var c2 = x2.Descendants("AC").First().Descendants("CLASS");
    
                // this one gives the distinct union of the two, you can put that into the result xdoc.
                var cComb =
                    c1
                    .Union(c2)
                    .Distinct(new ClassComparer()) // this uses the IEqualityComparer from below
                    .OrderBy(c => c.Attribute("Name").Value);
            }
        }
    
        // This is required for Union to work. (Also Intersect etc)
        class ClassComparer : IEqualityComparer<XElement> {
            public bool Equals(XElement x, XElement y) { return x.Attribute("Name").Value == y.Attribute("Name").Value; }
            public int GetHashCode(XElement obj) { return obj.Attribute("Name").Value.GetHashCode(); }
        }
    }
