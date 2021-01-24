    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication108
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                XNamespace cnrNs = root.GetNamespaceOfPrefix("cnr");
                var results = doc.Descendants(cnrNs + "PatientId").Select(x => new {
                               value = (string)x.Element(cnrNs + "IdValue"),
                               scheme = (string)x.Element(cnrNs + "IdScheme")
                }).ToList();
                 
            }
        }
    }
