    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication104
    {
        class Program
        {
     
             static void Main(string[] args)
            {
                string xml = "<root><para>This<brk/>is<brk/>a<brk/>bold tag.</para></root>";
                XElement root = XElement.Parse(xml);
                XElement para = root.Element("para");
                List<XElement> children = para.Elements().ToList();
                foreach (XElement child in children)
                {
                    root.Add(new XElement("para", child.NextNode.ToString()));
                }
                 children.Remove();
            }
        }
    }
