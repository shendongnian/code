    [XmlRoot("doc")]
        public class Doc
        {
            [XmlArray("field")]
            public Field[] Fields
            {
                get;
                set;
            }
        }
