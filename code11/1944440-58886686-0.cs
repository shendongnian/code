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
                XmlSerializer serializer = new XmlSerializer(typeof(ButiksCollection));
                ButiksCollection butik = (ButiksCollection)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "ButikerOmbud")]
        public class ButiksCollection
        {
            [XmlElement(ElementName = "Info")]
            public Info Info { get; set; }
            [XmlElement(ElementName = "ButikOmbud")]
            public List<Butik> Butiker { get; set; }
        }
        [XmlRoot(ElementName = "ButikOmbud")]
        [XmlInclude(typeof(StoreAssortmentViewModel))]
        [XmlInclude(typeof(AgentAssortmentViewModel))]
        public class Butik
        {   
            [XmlElement(ElementName = "Typ")]
            public string Typ { get; set; }
            [XmlElement(ElementName = "Nr")]
            public string Nr { get; set; }
        }
        public class Info
        {
            public string Meddelande { get; set; }
        }
        public class StoreAssortmentViewModel : Butik
        {
        }
        public class AgentAssortmentViewModel : Butik
        {
        }
    }
