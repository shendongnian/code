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
                XmlSerializer serializer = new XmlSerializer(typeof(ProcessType));
                ProcessType processType = (ProcessType)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "ProcessType", Namespace = "TalendFile.xsd")] 
        public class ProcessType
        {
            [XmlAttribute("defaultContext")]
            public string defaultContext { get; set; }
            [XmlAttribute("jobType")]
            public string jobType { get; set; }
            [XmlElement("context", Namespace = "")]
            public List<Context> context { get; set; }
            [XmlArray("parameters", Namespace = "")]
            [XmlArrayItem("elementParameter", Namespace = "")]
            public List<Parameters> parameters { get; set; } 
       }
       [XmlRoot("context", Namespace = "")]
       public class Context
       {
           [XmlAttribute("confirmationNeeded")]
           public string confirmationNeeded { get; set; }
           [XmlAttribute("name")]
           public string name { get; set; }
           [XmlElement("contextParameter", Namespace = "")]
           public ContextParameter contextParameter { get; set; }
       }
       [XmlRoot("contextParameter", Namespace = "")]
       public class ContextParameter
       {
           [XmlAttribute("comment")]
           public string comment { get; set; }
           [XmlAttribute("name")]
           public string name { get; set; }
           [XmlAttribute("prompt")]
           public string prompt { get; set; }
           [XmlAttribute("promptNeeded")]
           public string promptNeeded { get; set; }
           [XmlAttribute("type")]
           public string type { get; set; }
           [XmlAttribute("value")]
           public int value { get; set; }
       }
        [XmlRoot("parameters", Namespace = "")]
       public class Parameters
       {
           [XmlAttribute("field")]
           public string field { get; set; }
           [XmlAttribute("name")]
           public string name { get; set; }
           [XmlAttribute("show", Namespace = "")]
           public string show { get; set; }
           private int? _value { get; set; }
           [XmlAttribute("value")]
           public string value {
               get { return _value.ToString(); }
               set { _value = value == string.Empty ? (int?)null : int.Parse(value); }
           }
       }
    }
