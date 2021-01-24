     public class QTMMain
        {
            [XmlAttribute("TYPE")]
            public string TYPE { get; set; }
    
            [XmlText]
            public string Value { get; set; }
            public string DEVICE_TYPE { get; set; }
            public string DEVICE_ID { get; set; }
            //[XmlType(TypeName = "DEVICE_TYPE")]
            public string SWITCH_ID { get; set; }
            //[XmlType(TypeName = "DATE_TIME")]
            public string DATE_TIME { get; set; }
            public List<QTMStats> QTMStats { get; set; }
            public List<QTM> QTM { get; set; }
    }
