    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication9
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<WForm> wforms = doc.Descendants("wForm")
                    .Select(x => new WForm() { number = (int)x.Attribute("number"), element = x })
                    .ToList();
                var results = (from vElement in doc.Descendants("vElement")
                               join wForm in wforms on (int)vElement.Attribute("number") equals wForm.number into v
                               from wForm in v.DefaultIfEmpty()
                               select new { vElement = vElement, wForm = wForm}
                              ).ToList();
                foreach (var result in results)
                {
                    if (result.vElement.Element("elB") != null)
                    {
                        if(result.wForm != null) result.wForm.delete = false;
                        continue;
                    }
                    else
                    {
                        if ((result.wForm != null) && (result.wForm.element != null))
                        {
                            continue;
                        }
                        else
                        {
                            int number = (int)result.vElement.Attribute("number");
                            Console.WriteLine("Remove vElement : '{0}'", number);
                            result.vElement.Remove();
                        }
                    }
                }
                foreach (WForm wForm in wforms)
                {
                    if (wForm.delete)
                    {
                        Console.WriteLine("Remove wForm : '{0}'", wForm.number);
                        wForm.element.Remove();
                    }
                }
                Console.ReadLine();
            }
        }
        public class WForm
        {
            public int number { get; set; }
            public bool delete = true;
            public XElement element { get; set; }
        }
    }
