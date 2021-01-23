       public class RootClass
        {
            public Info info { get; set; }
            public Etcetera etc { get; set; }
        }
        public class Info
        {
            [XmlElement]
            public string InfoStr { get; set; }
            [XmlElement]
            public int InfoInt { get; set; }
        }
        public class Etcetera
        {
            [XmlElement]
            public string EtceteraValue { get; set; }
        }
