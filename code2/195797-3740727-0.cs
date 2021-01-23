    using System;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main()
        {
            string xml = @"
    <root>
      <element1/>
      <element2/>
      <element3/>
      <element4/>
      <element5/>
    </root>";
            XDocument doc = XDocument.Parse(xml);
            XElement x = doc.Root.Element("element2");
            XElement y = doc.Root.Element("element4");
            x.ReplaceWith(y);
            y.ReplaceWith(x);
            Console.WriteLine(doc);
        }
    }
