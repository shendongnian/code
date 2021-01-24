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
            const string URL = "https://samples.openweathermap.org/data/2.5/weather?q=London&mode=xml&appid=b6907d289e10d714a6e88b30761fae22";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
                XElement temperature = doc.Descendants("temperature").FirstOrDefault();
                temperature.SetAttributeValue("value", 281);
     
            }
        }
    }
