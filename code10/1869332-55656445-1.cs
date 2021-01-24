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
                               
            }
        }
        [Serializable()]
        [XmlRoot("EnvironmentNodeConfigurationParameters")]
        public class EnvironmentNodeConfigurationParameters
        {
            [XmlElement("ComplexDeviceParameterList")]
            public ComplexDeviceParameterList cdpl = new ComplexDeviceParameterList();
        }
        [Serializable()]
        public class ComplexDeviceParameterList
        {
            [XmlElement("ComplexNodeConfigurations")]
            public List<ComplexNodeConfigurations> cnc = new List<ComplexNodeConfigurations>();
        }
        [Serializable()]
        public class ComplexNodeConfigurations
        {
            [XmlElement("ComplexNodeParameterList")]
            public ComplexNodeParameterList cnc2 = new ComplexNodeParameterList();
        }
        [Serializable()]
        public class ComplexNodeParameterList
        {
            [XmlElement("NodeConfigurations")]
            public List<NodeConfigurations> nodeList = new List<NodeConfigurations>();
        }
        [Serializable()]
        public class NodeConfigurations
        {
            [XmlElement("EnvironmentLinkParams")]
            public List<EnvironmentLinkParams> elplist = new List<EnvironmentLinkParams>();
        }
        [Serializable()]
        public class EnvironmentLinkParams
        {
            [XmlElement("KeyValuePair")]
            public KP kvp = new KP();
        }
        [Serializable()]
        public class KP
        {
            [XmlElement("NodeConfigurations")]
            public List<NodeConfigurations> nodeList = new List<NodeConfigurations>();
            [XmlAttribute("Key")]
            public string key = "IPAddress";
            [XmlAttribute("Value")]
            public string value = "192.168.1.250";
        }
     
    }
