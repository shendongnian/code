    using System;
    using System.Xml;
    
    class Program
    {
        static void Foo(object o)
        {
            Console.WriteLine("object overload");
        }
    
        static void Foo(XmlNode node)
        {
            Console.WriteLine("XmlNode overload");
        }
    
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<root><child/></root>");
    
            foreach (var nodeVar in doc.DocumentElement.ChildNodes)
            {
                Foo(nodeVar);
            }
    
            foreach (XmlNode nodeXmlNode in doc.DocumentElement.ChildNodes)
            {
                Foo(nodeXmlNode);
            }
        }
    }
