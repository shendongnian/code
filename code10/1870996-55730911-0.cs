    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
                XElement result = doc.Root;
                List<PRecord> records = new List<PRecord>();
                List<XElement> systems = result.Elements("MasterSystem").ToList();
                systems.AddRange(result.Elements("AliasSystem"));
                foreach (XElement system in systems)
                {
                    PRecord newRecord = new PRecord();
                    records.Add(newRecord);
                    newRecord.systemType = system.Name.LocalName;
                    newRecord.creationDate = (DateTime)system.Descendants("creationDate").FirstOrDefault();
                    XElement partReference = system.Descendants("partReference").FirstOrDefault();
                    XElement xPartNumber = partReference.Element("partNumber");
                    newRecord.partNumber = (string)xPartNumber;
                    newRecord.partNumber_confidence = (int)xPartNumber.Attribute("confidence");
                    newRecord.partType = (string)partReference.Element("partType");
                    newRecord.description = (string)partReference.Element("description");
                    newRecord.revision = (string)partReference.Element("revision");
                    newRecord.status = (string)partReference.Element("status");
                    newRecord.category = (string)partReference.Element("category");
                    newRecord.source = (string)partReference.Element("source");
                    newRecord.productLifeCycle = (string)partReference.Element("productLifeCycle");
                    List<XElement> aliases = partReference.Descendants("alias").ToList();
                    foreach (XElement alias in aliases)
                    {
                        if (newRecord.aliases == null) newRecord.aliases = new List<ARecord>();
                        ARecord newARecord = new ARecord();
                        newRecord.aliases.Add(newARecord);
                        newARecord.a_partNumber = (string)alias.Element("partNumber");
                        newARecord.a_DnBCode = (string)alias.Element("DnBCode");
                        newARecord.a_ManufName = (string)alias.Element("name");
                        newARecord.a_category = (string)alias.Element("status");
                        newARecord.a_status = (string)alias.Element("category");
                    }
                }
     
            }
        }
        public class PRecord
        {
            public string systemType { get; internal set; }
            public DateTime creationDate { get; internal set; }
            public string system { get; internal set; }
            public string partNumber { get; internal set; }
            public int partNumber_confidence { get; internal set; }
            public string partType { get; internal set; }
            public string description { get; internal set; }
            public string revision { get; internal set; }
            public string status { get; internal set; }
            public string part_source { get; internal set; }
            public string category { get; internal set; }
            public string source { get; internal set; }
            public string productLifeCycle { get; internal set; }
            public List<ARecord> aliases { get; internal set; }
        }
        public class ARecord
        {
            public string a_partNumber { get; set; }
            public string a_ManufName { get; set; }
            public string a_DnBCode { get; set; }
            public string a_category { get; set; }
            public string a_status { get; set; }
        }
    }
