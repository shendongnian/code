    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                //put response string here
                string response = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(response);
                List<Producer> producers = doc.Descendants("Producer").Select(x => new Producer()
                {
                    ProducerName = (string)x.Element("ProducerName"),
                    ResidentState = (string)x.Element("ResidentState"),
                    ResidentCity = (string)x.Element("ResidentCity"),
                    ProducerStatus = (string)x.Element("ProducerStatus"),
                    ProducerCode = (string)x.Element("ProducerCode"),
                    MasterCode = (string)x.Element("MasterCode"),
                    NationalCode = (string)x.Element("NationalCode"),
                    LegacyCode = (string)x.Element("LegacyCode"),
                    ProducingBranchCode = (string)x.Element("ProducingBranchCode"),
                    CategoryCode = (string)x.Element("CategoryCode")
                }).ToList();
                
                Dictionary<string, Producer> dict1 = producers
                    .GroupBy(x => x.ProducerCode, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                Dictionary<string, List<Producer>> dict2 = producers
                    .GroupBy(x => x.ProducerCode, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
        public class Producer
        {
            public string ProducerName { get; set; }
            public string ResidentState  { get; set; }
            public string ResidentCity  { get; set; }
            public string ProducerStatus { get; set; }
            public string ProducerCode { get; set; }
            public string MasterCode { get; set; }
            public string NationalCode { get; set; }
            public string LegacyCode { get; set; }
            public string ProducingBranchCode { get; set; }
            public string CategoryCode { get; set; }
        }
    }
