    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication108
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                StringReader sReader = new StringReader(xml);
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Ignore;
                XmlReader reader = XmlReader.Create(sReader, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(ApplianceOutput));
                ApplianceOutput applicance = (ApplianceOutput)serializer.Deserialize(reader);
     
            }
        }
        [XmlRoot("APPLIANCE_LIST_OUTPUT")]
        public class ApplianceOutput
        {
            [XmlElement("RESPONSE")]
            public Response response { get; set; }
        }
        [XmlRoot("RESPONSE")]
        public class Response
        {
            public DateTime date { get; set; }
            [XmlArray("APPLIANCE_LIST")]
            [XmlArrayItem("APPLIANCE")]
            public List<Appliance> appliances { get; set; }
        }
        public class Appliance
        {
            public string ID { get; set; }
            public string UUID { get; set; }
            public string NAME { get; set; }
            public string SOFTWARE_VERSION { get; set; }
            public int RUNNING_SLICES_COUNT { get; set; }
            public int RUNNING_SCAN_COUNT { get; set; }
            public string STATUS { get; set; }
        }
      
    }
