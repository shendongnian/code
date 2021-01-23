    using System;
    using System.Xml;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main() 
        {
            using (XmlWriter writer = XmlWriter.Create("test.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("log");
                writer.WriteStartElement("entries");
                
                for (int i = 0; i < 10; i++)
                {
                    XElement element = new XElement("entry", "Entry " + i);
                    element.WriteTo(writer);
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
