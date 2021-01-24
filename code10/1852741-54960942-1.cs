    [XmlRoot(ElementName = "TestResult", Namespace = "http://tempuri.org/")]
        public class TestResult
        {
            [XmlElement(ElementName = "code", Namespace = "http://tempuri.org/")]
            public string Code { get; set; }
            [XmlElement(ElementName = "msg", Namespace = "http://tempuri.org/")]
            public string Msg { get; set; }
            [XmlElement(ElementName = "sent", Namespace = "http://tempuri.org/")]
            public string Sent { get; set; }
        }
    
        [XmlRoot(ElementName = "TestResponse", Namespace = "http://tempuri.org/")]
        public class TestResponse
        {
            [XmlElement(ElementName = "TestResult", Namespace = "http://tempuri.org/")]
            public TestResult TestResult { get; set; }
            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }
        }
    
        [XmlRoot(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public class Body
        {
            [XmlElement(ElementName = "TestResponse", Namespace = "http://tempuri.org/")]
            public TestResponse TestResponse { get; set; }
        }
    
        [XmlRoot(ElementName = "Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public class Envelope
        {
            [XmlElement(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
            public Body Body { get; set; }
            [XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Soap { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsd { get; set; }
        }
