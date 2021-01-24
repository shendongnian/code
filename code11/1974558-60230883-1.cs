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
                readXML();
            }
            public static void readXML()
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                reader.ReadToFollowing("DewesoftSetup");
                XmlSerializer serializer = new XmlSerializer(typeof(DewesoftDevices));
                DewesoftDevices setup = (DewesoftDevices)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "DewesoftSetup")]
        public class DewesoftDevices
        {
            [XmlElement(ElementName = "Devices")]
            public List<Devices> devices { get; set; }
     
        }
        public class Devices
        {
            public string StartStoreTime;
            public int SampleRate;
            public int IBRate;
            public int AAFsr;
            public int MaxSampling;
            [XmlElement(ElementName = "Device")]
            public List<DeviceType> deviceType { get; set; }
        }
        public class DeviceType
        {
            [XmlAttribute(AttributeName = "Type")]
            public string deviceType;
            [XmlElement(ElementName = "Slot")]
            public List<Slot> slot { get; set; }
        }
        public class Slot
        {
            public string Range { get; set; }
        }
    }
