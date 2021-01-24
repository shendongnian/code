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
                XElement root = doc.Root;
                XNamespace ns2 = root.GetNamespaceOfPrefix("ns2");
                var results = doc.Descendants(ns2 + "Vehicle").Select(x => new
                {
                    vehicleIdentNumber = (string)x.Element(ns2 + "VehicleIdentNumber"),
                    originalEquipmentValueGross = (string)x.Descendants(ns2 + "OriginalEquipmentValueGross").FirstOrDefault()
                }).ToList();
            }
        }
      
    }
