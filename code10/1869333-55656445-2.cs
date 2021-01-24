    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication108
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(EnvironmentNodeConfigurationParameters));
                EnvironmentNodeConfigurationParameters parameters = (EnvironmentNodeConfigurationParameters)serializer.Deserialize(reader);
                List<ComplexNodeConfigurations> cncs = parameters.cdpl.cnc;
                foreach (ComplexNodeConfigurations cnc in cncs)
                {
                    List<NodeConfigurations> nodeList = cnc.cnc2.nodeList;
                    nodeList = nodeList.OrderBy(x => x.guid).ToList();
                }
            }
        }
        [Serializable()]
        [XmlRoot("EnvironmentNodeConfigurationParameters")]
        public class EnvironmentNodeConfigurationParameters
        {
            [XmlElement("ComplexDeviceParameterList")]
            public ComplexDeviceParameterList cdpl { get; set; }
        }
        [Serializable()]
        public class ComplexDeviceParameterList
        {
            [XmlElement("ComplexNodeConfigurations")]
            public List<ComplexNodeConfigurations> cnc { get; set; }
        }
        [Serializable()]
        public class ComplexNodeConfigurations
        {
            [XmlElement("ComplexNodeParameterList")]
            public ComplexNodeParameterList cnc2 { get; set; }
        }
        [Serializable()]
        public class ComplexNodeParameterList
        {
            [XmlElement("NodeConfigurations")]
            public List<NodeConfigurations> nodeList { get; set; }
        }
        [Serializable()]
        public class NodeConfigurations
        {
            [XmlElement("EnvironmentLinkParams")]
            public List<EnvironmentLinkParams> elplist { get; set; }
            [XmlAttribute("Guid")]
            public string guid { get; set; }
        }
        [Serializable()]
        public class EnvironmentLinkParams
        {
            [XmlElement("KeyValuePair")]
            public KP kvp { get; set; }
        }
        [Serializable()]
        public class KP
        {
            [XmlElement("NodeConfigurations")]
            public List<NodeConfigurations> nodeList { get; set; }
            [XmlAttribute("Key")]
            public string key { get; set; }
            [XmlAttribute("Value")]
            public string value { get; set; }
        }
    }
