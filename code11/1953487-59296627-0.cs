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
                XmlSerializer serializer = new XmlSerializer(typeof(CplexSol));
                CplexSol cplexsol = (CplexSol)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("CPLEXSolutions")]
        public class CplexSol
        {
            [XmlElement("CPLEXSolution")]
            public List<CPLEXSolution> Solutions { get; set; }
        }
        public class CPLEXSolution
        {
            [XmlElement("header")]
            public string Header { get; set; }
            [XmlArray("variables")]
            [XmlArrayItem("variable")]
            public List<CplexVariable> CplexVariables { get; set; }
        }
        public class CplexVariable
        {
            [XmlAttribute("name")]
            public string name { get; set; }
            [XmlAttribute("index")]
            public string index { get; set; }
            [XmlAttribute("value")]
            public string value { get; set; }
        }
    }
