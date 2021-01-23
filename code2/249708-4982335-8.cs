    using System;
    using System.Xml;
    
    namespace ConsoleApplication6
    {
        internal class Program
        {
            public static void ReadData(XmlReader reader)
            {
                reader.ReadStartElement("root");
    
                while (reader.IsStartElement("Person"))
                {
                    ReadPerson(reader);
                }
    
                reader.ReadEndElement( /* root */);
            }
    
            public static void ReadPerson(XmlReader reader)
            {
                Console.WriteLine(reader.GetAttribute("Type"));
                bool isEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("Person");
                while (reader.IsStartElement("Home"))
                {
                    ReadHome(reader);
                }
                if (!isEmpty)
                {
                    reader.ReadEndElement( /* Person */);
                }
            }
    
            public static void ReadHome(XmlReader reader)
            {
                Console.WriteLine("\t" + reader.GetAttribute("Type"));
                bool isEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("Home");
    
                if (!isEmpty)
                {
                    reader.Skip();
                    reader.ReadEndElement( /* Home */);
                }
            }
    
            private static void Main(string[] args)
            {
                var settings = new XmlReaderSettings { IgnoreWhitespace = true };
                using (var xr = XmlReader.Create("XMLFile1.xml", settings))
                {
                    ReadData(xr);
                }
                Console.ReadKey();
            }
        }
    }
