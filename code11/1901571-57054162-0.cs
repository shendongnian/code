        [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Body
        {
            [XmlElement(ElementName = "faultcode", Namespace = "")]
            public string Faultcode { get; set; }
            [XmlElement(ElementName = "faultstring", Namespace = "")]
            public string Faultstring { get; set; }
            [XmlElement(ElementName = "faultactor", Namespace = "")]
            public string Faultactor { get; set; }
            [XmlElement(ElementName = "detail", Namespace = "")]
            public string Detail { get; set; }
        }
