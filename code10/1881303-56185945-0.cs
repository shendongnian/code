    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication3
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(FullLoadPerformanceGrid));
                FullLoadPerformanceGrid load = (FullLoadPerformanceGrid)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "ComputationData", Namespace = "")] 
        public class FullLoadPerformanceGrid
        {
            [XmlAttribute("DataType", Namespace = "")]
            public string DataType { get; set; }
            [XmlElement(ElementName = "Mode", Namespace = "")]
            public Mode mode { get; set; }
        }
        [XmlRoot(ElementName = "Mode", Namespace = "" )]
        public class Mode
        {
            [XmlAttribute("Name", Namespace = "")]
            public string name { get; set; }
            [XmlArray("Area", Namespace = "")]
            [XmlArrayItem("Point", Namespace = "")]
            public List<Point> points { get; set; }
        }
        [XmlRoot(ElementName = "Point", Namespace = "")]
        public class Point
        {
            [XmlAttribute("PointNumber", Namespace = "")]
            public int pointNumber { get; set; }
            [XmlAttribute("Speed", Namespace = "")]
            public decimal speed { get; set; }
            [XmlAttribute("Power", Namespace = "")]
            public decimal power { get; set; }
            [XmlAttribute("Value", Namespace = "")]
            public int value { get; set; }
        }
    }
