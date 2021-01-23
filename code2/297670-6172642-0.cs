    using System;
    using System.Xml.Serialization;
    
    namespace XmlEntities {
        [XmlRoot("XmlDocRoot")]
        public class RootClass {
            private int attribute_id;
    
            [XmlAttribute("id")]
            public int Id {
                get { return attribute_id; }
                set { attribute_id = value; }
            }
        }
    }
