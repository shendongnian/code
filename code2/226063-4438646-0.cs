     [XmlRoot("doc")]
        public class Doc
        {
            [XmlElement("field",Order = 1)]
            public Field Id
            {
                get;
                set;
            }
            [XmlElement("field", Order = 2)]
            public Field Name
            {
                get;
                set;
            }
        }
    
        [XmlRoot("doc")]
        public class Field
        {
            [XmlText]
            public string Value
            {
                get;
                set;
            }
    
            [XmlAttribute("name")]
            public string Name
            {
                get;
                set;
            }
        }
    enter code here
