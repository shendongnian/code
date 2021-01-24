    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication152
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<FBTType> fBTTypes = doc.Descendants("FBType").Select(x => new FBTType()
                {
                    guid = (string)x.Attribute("GUID"),
                    typeName = (string)x.Attribute("Name"),
                    comment = (string)x.Attribute("Comment"),
                    ns = (string)x.Attribute("Namespace"),
                    name = (string)x.Element("Attribute").Attribute("Name"),
                    value = (string)x.Element("Attribute").Attribute("Value"),
                    identification = (string)x.Element("Identification").Attribute("Standard"),
                    organization = (string)x.Element("VersionInfo").Attribute("Organization"),
                    version = (string)x.Element("VersionInfo").Attribute("Version"),
                    author = (string)x.Element("VersionInfo").Attribute("Author"),
                    date = (DateTime)x.Element("VersionInfo").Attribute("Date"),
                    remarks = (string)x.Element("VersionInfo").Attribute("Remarks"),
                    eventInputs = x.Descendants("EventInputs").FirstOrDefault().Elements("Event").Select(y => (string)y.Attribute("Name")).ToArray(),
                    eventOutputs = x.Descendants("EventOutputs").FirstOrDefault().Elements("Event").Select(y => (string)y.Attribute("Name")).ToArray(),
                }).ToList();
                foreach (FBTType fbTType in fBTTypes)
                {
                    fbTType.print();
                }
                Console.ReadLine();
            }
        }
        public class FBTType
        {
            public string guid { get; set; }
            public string typeName { get; set; }
            public string comment { get; set; }
            public string ns { get; set; }
            public string name { get; set; }
            public string value { get; set; }
            public string identification { get; set; }
            public string organization { get; set; }
            public string version { get; set; }
            public string author { get; set; }
            public DateTime date { get; set; }
            public string remarks { get; set; }
            public string[] eventInputs { get; set; }
            public string[] eventOutputs { get; set; }
            public void print()
            {
                Console.WriteLine("GUID : '{0}'",guid);
                Console.WriteLine("Type Name : '{0}'",typeName);
                Console.WriteLine("Comment : '{0}'",comment);
                Console.WriteLine("Namespace : '{0}'",ns);
                Console.WriteLine("Name : '{0}'",name);
                Console.WriteLine("Value : '{0}'",value);
                Console.WriteLine("Identification : '{0}'",identification);
                Console.WriteLine("Organization : '{0}'",organization);
                Console.WriteLine("Version : '{0}'",version);
                Console.WriteLine("Author: '{0}'",author);
                Console.WriteLine("Date : '{0}'",date.ToString());
                Console.WriteLine("Remarks : '{0}'",remarks);
                Console.WriteLine("Event Inputs : '{0}'",string.Join(",", eventInputs));
                Console.WriteLine("Envent Outputs : '{0}'", string.Join(",", eventOutputs));
            }
        }
    }
