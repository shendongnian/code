    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication137
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> properties = doc.Descendants("Property").ToList();
                for (int i = properties.Count - 1; i >= 0; i-- )
                {
                    XElement property = properties[i];
                    string value = (string)property.Attribute("Value");
                    if (value.Contains("^"))
                    {
                        property.ReplaceWith(ReplaceElement(property));
                    }
                }
            }
            static List<XElement> ReplaceElement(XElement element)
            {
                List<XElement> elements = new List<XElement>();
                string name = (string)element.Attribute("Name");
                string baseName = Regex.Match(name, @"[^\d]+").Value;
                string value = (string)element.Attribute("Value");
                string[] splitValues = value.Split(new char[] { '^' }).ToArray();
                for (int i = 1; i <= splitValues.Length; i++)
                {
                    elements.Add(new XElement("Property", new XAttribute[] { 
                        new XAttribute("Name", baseName + i.ToString()),
                        new XAttribute("Value", splitValues[i - 1])
                    }));
                }
                return elements;
            }
        }
     
    }
