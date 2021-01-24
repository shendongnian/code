    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    namespace ConsoleApp4
    {
    class Program
    {
        static void Main(string[] args)
        {
            K5project k5Project = LoadXml("file.xml");
            var lastModbusport = k5Project.Networks.Modbus.Modbusport.Last();
            //here lastModbusport contain last Modbusport... enjoy it
        }
        private static K5project LoadXml(string filename)
        {
            var serializer = new XmlSerializer(typeof(K5project));
            if (!File.Exists(filename))
            {
                return null;
            }
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return (K5project)serializer.Deserialize(fs);
            }
        }
    }
    [XmlRoot(ElementName = "modbusitem")]
    public class Modbusitem
    {
        [XmlAttribute(AttributeName = "ope")]
        public string Ope { get; set; }
        [XmlAttribute(AttributeName = "offset")]
        public string Offset { get; set; }
        [XmlAttribute(AttributeName = "symbol")]
        public string Symbol { get; set; }
    }
    [XmlRoot(ElementName = "modbusreq")]
    public class Modbusreq
    {
        [XmlElement(ElementName = "modbusitem")]
        public List<Modbusitem> Modbusitem { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "mode")]
        public string Mode { get; set; }
    }
    [XmlRoot(ElementName = "modbusport")]
    public class Modbusport
    {
        [XmlElement(ElementName = "modbusreq")]
        public List<Modbusreq> Modbusreq { get; set; }
        [XmlAttribute(AttributeName = "kind")]
        public string Kind { get; set; }
        [XmlAttribute(AttributeName = "address")]
        public string Address { get; set; }
    }
    [XmlRoot(ElementName = "modbus")]
    public class Modbus
    {
        [XmlElement(ElementName = "modbusport")]
        public List<Modbusport> Modbusport { get; set; }
    }
    [XmlRoot(ElementName = "networks")]
    public class Networks
    {
        [XmlElement(ElementName = "modbus")]
        public Modbus Modbus { get; set; }
    }
    [XmlRoot(ElementName = "K5project")]
    public class K5project
    {
        [XmlElement(ElementName = "networks")]
        public Networks Networks { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }
    }
