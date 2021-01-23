    using System;
    using System.Text;
    using System.Xml;
    
    class Test
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateElement("Foo"));
            doc.DocumentElement.InnerXml = "Test";      
            StringBuilder result = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(result))
            {
                doc.WriteContentTo(writer);
            }
            Console.WriteLine(result);
        }
    }
