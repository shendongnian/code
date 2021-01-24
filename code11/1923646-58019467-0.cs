    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(Course));
                Course course = (Course)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("course")]
        public class Course
        {
            [XmlAttribute("type")]
            public string _type { get; set; }
            public DateTime _date { get; set; }
            [XmlAttribute("date")]
            public string date {
                get { return _date.ToString("dd.MM.yyyy"); }
                set { _date = DateTime.ParseExact(value, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture); } 
            }
            
            
            private string _code { get; set; }
            [XmlElement("line")]
            public Line line
            {
                get { return new Line() { code = _code }; }
                set { _code = value.code; }
            }
        }
        [XmlRoot("line")]
        public class Line
        {
            [XmlAttribute("code")]
            public string code { get; set; }
        }
    }
