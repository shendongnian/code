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
                 XNamespace xyzNs = root.GetNamespaceOfPrefix("xyz");
                 List<EmployeeDetail> employeeDatails = doc.Descendants(xyzNs + "EmployeeDetail").Select(x => new EmployeeDetail()
                 {
                     name = (string)x.Attribute("name"),
                     state = (string)x.Element(xyzNs + "State"),
                     assignments = x.Descendants(xyzNs + "Assignment").Select(y => new Assignment()
                     {
                         department = (string)y.Element(xyzNs + "JoiningDetail").Attribute("Department"),
                         joinDate = (DateTime)y.Descendants(xyzNs + "JoiningDate").FirstOrDefault()
                     }).ToList()
                 }).ToList();
             }
        }
        public class EmployeeDetail
        {
            public string name { get; set; }
            public string state { get; set; }
            public List<Assignment> assignments { get; set; }
        }
        public class Assignment
        {
            public string department { get; set; }
            public DateTime joinDate { get;set; }
        }
      
    }
