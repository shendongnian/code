       [XmlRoot("blind")]
        public class Blind
        {
            [XmlArray("playlist")]
            [XmlArrayItem("extrait")]
            public List<Extrait> extrait { get; set; }
        }
        public class Extrait
        {
        }
