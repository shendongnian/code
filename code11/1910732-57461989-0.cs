    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication124
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                   "<Company>\n" +
                      "<Name value=\"SomeCompany\"> </Name>\n" +
                      "<Count value =\"500\"/>\n" +
                   "</Company>";
                XDocument doc = XDocument.Parse(input);
                List<XElement> nodes = doc.Descendants().ToList();
                for (int i = nodes.Count - 1; i >= 0; i--)
                {
                    XElement node = nodes[i];
                    if ((string)node.Attribute("value") != null)
                    {
                        node.ReplaceWith(new XElement(node.Name.LocalName, new object[] {
                            node.Attributes().Where(x => x.Name.LocalName != "value"),
                            (string)node.Attribute("value"),
                            node.DescendantNodes()
                        }));
                    }
                }
            }
        }
    }
