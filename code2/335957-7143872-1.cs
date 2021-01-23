    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            string xml = "<parent><foo id='bar' /><foo id='baz' /></parent>";
            XDocument doc = XDocument.Parse(xml);
            string idToFind = "bar";
            XElement selectedElement = doc.Descendants()
                .Where(x => (string) x.Attribute("id") == idToFind).FirstOrDefault();
            Console.WriteLine(selectedElement);
        }
    }
