    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement rtn = doc.Descendants().Where(x => x.Name.LocalName == "return").FirstOrDefault();
                string output = "";
                foreach (XElement child in rtn.Descendants())
                {
                    string name = child.Name.LocalName;
                    if (name.Contains("validation"))
                    {
                        string nil = child.Attributes().First().Value;
                        output = name + " : " + nil;
                    }
                    else
                    {
                        output = name + " : " + (string)child;
                    }
                    Console.WriteLine(output);
                }
                Console.ReadLine();
            }
        }
    }
