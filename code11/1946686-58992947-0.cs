        public class data
        {
            public string id { get; set; }
            
            [XmlElement("property")]
            public property[] Properties { get; set; }
        }
