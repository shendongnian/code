    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication120
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                using (var reader = new StreamReader(FILENAME, Encoding.UTF8))
                {
                    var serializer = new XmlSerializer(typeof(ArrayOfAgency));
                    ArrayOfAgency agencies = (ArrayOfAgency)serializer.Deserialize(reader);
                }
            }
        }
        public class ArrayOfAgency
        {
            public DbAgencyDefinition DbAgencyDefinition { get; set; }
        }
        public class DbAgencyDefinition
        {
            public string Name { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string GtfsZipUrlDirectory { get; set; }
            public string GtfsZipUrlFileName { get; set; }
            public string State { get; set; }
        }
     
    }
