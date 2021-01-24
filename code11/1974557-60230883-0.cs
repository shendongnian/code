    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                reader.ReadToFollowing("DewesoftSetup");
                XmlSerializer serializer = new XmlSerializer(typeof(DewesoftSetup));
                DewesoftSetup setup = (DewesoftSetup)serializer.Deserialize(reader);
     
            }
      
        }
        [XmlRoot("DewesoftSetup")]
        public class DewesoftSetup
        {
            [XmlElement("Devices")]
            public Devices devices { get; set; }
        }
        public class Devices
        {
            public string StartStoreTime;
            public int SampleRate;
            public int IBRate;
            public int AAFsr;
            public int MaxSampling;
        }
     
    }
