    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                SplitXML(args[0], args[1]);
            }
    
            private static void SplitXML(string fileNameA, string fileNameB)
            {
                int deleteCount;
                XmlNodeList childNodes;
                XmlReader reader;
                XmlTextWriter writer;
                XmlDocument doc;
    
                // ------------- Process FileA
                reader = XmlReader.Create(fileNameA);
                doc = new XmlDocument();
                doc.Load(reader);
                
                childNodes = doc.DocumentElement.ChildNodes;
                deleteCount = childNodes.Count / 2;
    
                for (int i = 0; i < deleteCount; i++)
                {
                    doc.DocumentElement.RemoveChild(childNodes.Item(0));
                }
                writer = new XmlTextWriter("FileC", null);
                doc.Save(writer);
    
                // ------------- Process FileB
                reader = XmlReader.Create(fileNameB);
                doc = new XmlDocument();
                doc.Load(reader);
    
                childNodes = doc.DocumentElement.ChildNodes;
    
                for (int i = deleteCount + 1; i < childNodes.Count; i++)
                {
                    doc.DocumentElement.RemoveChild(childNodes.Item(deleteCount));
                }
                writer = new XmlTextWriter("FileD", null);
                doc.Save(writer);
    
            }
        }
    }
