    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    namespace LinqToXmlSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement x = XElement.Load("http://api.hostip.info/?ip=12.215.42.19");
                foreach (XElement hostip in x.Descendants("Hostip"))
                {
                    string country = Convert.ToString(hostip.Element("countryName").Value);
                    Console.WriteLine(country);
                }
                Console.ReadLine();
            }
        }
    }
