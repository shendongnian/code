    using System.Xml.Linq;
    class Test
    {
        static void Main()
        {
            XDocument doc = new XDocument();
            doc.Add(new XElement("Test"));
            doc.Save("test.xml");
        }
    }
