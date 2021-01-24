    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> generated_items = doc.Descendants("generated-items").ToList();
                foreach (XElement generated_item in generated_items)
                {
                    generated_item.AddAfterSelf(generated_item.Descendants());
                    generated_item.Remove();
                }
            }
        }
    }
