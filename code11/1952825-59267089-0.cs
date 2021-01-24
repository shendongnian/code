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
                Dictionary<int, WForm> wforms = doc.Descendants("wForm")
                    .Select(x => new WForm() { number = (int)x.Attribute("number"), element = x})
                    .GroupBy(x => x.number, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                var results = (from vElement in doc.Descendants("vElement")
                               join wForm in doc.Descendants("wForm") on (int)vElement.Attribute("number") equals (int)wForm.Attribute("number") into v
                               from wForm in v.DefaultIfEmpty()
                               select new { vElement = vElement, wForm = wForm }
                              ).ToList();
                foreach (var result in results)
                {
                    int number = (int)result.vElement.Attribute("number");
                    if (result.vElement.Element("elB") != null)
                    {
                        if(wforms.ContainsKey(number)) wforms[number].delete = false;
                        continue;
                    }
                    else
                    {
                        if ((result.wForm != null) && (result.wForm.Element("kB") != null))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Remove vElement : '{0}'", number);
                            result.vElement.Remove();
                        }
                    }
                }
                foreach (KeyValuePair<int, WForm> wForm in wforms)
                {
                    if (wForm.Value.delete)
                    {
                        Console.WriteLine("Remove wForm : '{0}'", wForm.Key);
                        wForm.Value.element.Remove();
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
