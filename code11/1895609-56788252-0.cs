         [XmlRoot(ElementName = "output", Namespace = "http://org/emedny/fts/")]
            public class Output
            {
                [XmlElement(ElementName = "fileName", Namespace = "http://org/emedny/fts/")]
                public string FileName { get; set; }
            }
        
            [XmlRoot(ElementName = "sendDataResponse", Namespace = "http://org/emedny/fts/")]
            public class SendDataResponse
            {
                [XmlElement(ElementName = "output", Namespace = "http://org/emedny/fts/")]
                public Output Output { get; set; }
                [XmlAttribute(AttributeName = "a", Namespace = "http://www.w3.org/2000/xmlns/")]
                public string A { get; set; }
                [XmlAttribute(AttributeName = "xmlns")]
                public string Xmlns { get; set; }
            }
        
            [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public class Body
            {
                [XmlElement(ElementName = "sendDataResponse", Namespace = "http://org/emedny/fts/")]
                public SendDataResponse SendDataResponse { get; set; }
            }
        
            [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public class Envelope
            {
                [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
                public Body Body { get; set; }
                [XmlAttribute(AttributeName = "soapenv", Namespace = "http://www.w3.org/2000/xmlns/")]
                public string Soapenv { get; set; }
            }
    
    
    .....
    
    
    using (var st = File.OpenRead(@"i_saved_your_request_here.xml"))
    {
    	var data = new XmlSerializer(typeof(Envelope)).Deserialize(st) as Envelope;
    	var output = data.Body.SendDataResponse.Output.FileName;
    }
