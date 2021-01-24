    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication122
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                XNamespace nsDiffgr = root.GetNamespaceOfPrefix("diffgr");
                XNamespace nsData = root.GetNamespaceOfPrefix("msdata");
                List<Department> deparments = doc.Descendants(ns + "Departments").Select(x => new Department()
                {
                    id = (string)x.Attribute(nsDiffgr + "id"),
                    code = (string)x.Element(ns + "Code"),
                    description = (string)x.Element(ns + "Description"),
                    rowOrder = (int)x.Attribute(nsData + "rowOrder")
                }).ToList();
                Dictionary<string, Department> dict = deparments
                    .GroupBy(x => x.id, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
        public class Department
        {
            public string id { get; set; }
            public string code { get; set; }
            public string description { get; set; }
            public int rowOrder { get;set;}
        }
    }
