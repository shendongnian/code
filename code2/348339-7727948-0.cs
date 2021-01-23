    [XmlRoot("ExceptionReport")]
        public partial class ExceptionReport
        {
            [XmlElement("Exception")]
            public List<Exception> Nodes { get; set; }
    
            public ExceptionReport()
            {
                Nodes = new List<Exception>();
            }
        }
        public class Exception
        {
            [XmlText]
            public string ExceptionText;
            [XmlAttribute("exceptionCode")]
            public int ExceptionCode;
            [XmlAttribute("locator")]
            public string Locator;
        }
