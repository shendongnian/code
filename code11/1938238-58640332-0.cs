    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication139
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement start = doc.Descendants("Start").FirstOrDefault();
                foreach (XElement element in start.Elements())
                {
                    switch (element.Name.LocalName)
                    {
                        case "step1" :
                            break;
                        case "step2":
                            break;
                        case "step3":
                            break;
                        case "step4":
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
