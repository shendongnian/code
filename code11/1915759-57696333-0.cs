        public class H204
        {
            [XmlAttribute(AttributeName = "Code")]
            public string Code { get; set; }
            [XmlElement(ElementName = "DW")]
            public  DW  dw{ get; set; }
        }
        public class DW
        {
            [XmlAttribute(AttributeName = "DW")]
            public string text { get; set; }
        }
