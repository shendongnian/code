        public abstract class EntityWithNumber
        {
            [XmlAttribute("No")]
            public int Number { get; set; }
        }
        
        public class Name : EntityWithNumber
        {
            [XmlText]
            public string Value { get; set; }
        }
        
        public class City : EntityWithNumber
        {
            [XmlText]
            public string Name { get; set; }
        }
        
        public class Route : EntityWithNumber
        {
            public Name Name { get; set; }
            public City City { get; set; }
        }
