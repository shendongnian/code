    [XmlRoot("SiteServer", Namespace="http://example.com/schemas/SiteServer")]
    public class SiteServer
    {        
        [XmlRoot("SiteServerRelationShip", Namespace="http://example.com/schemas/SiteServer")]
        public class Relationship
        {
            public string type { get; set; }
        }
        public string Name { get; set; }
        public Relationship Relate = new Relationship();
    }
    [XmlRoot("LocalServer", Namespace="http://example.com/schemas/LocalServer")]
    public class LocalServer
    {
        [XmlRoot("LocalServerRelationship", Namespace="http://example.com/schemas/LocalServer")]
        public class Relationship
        {
            public string type { get; set; }
        }
        public string Name { get; set; }
        public Relationship Relate = new Relationship();
    }
