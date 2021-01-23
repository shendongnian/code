    [XmlRoot("SiteServer", Namespace="http://youcompany.com/schemas/SiteServer")]
    public class SiteServer
    {        
        [XmlRoot("SiteServerRelationShip", Namespace="http://youcompany.com/schemas/SiteServer")]
        public class Relationship
        {
            public string type { get; set; }
        }
        public string Name { get; set; }
        public Relationship Relate = new Relationship();
    }
    [XmlRoot("LocalServer", Namespace="http://youcompany.com/schemas/LocalServer")]
    public class LocalServer
    {
        [XmlRoot("LocalServerRelationship", Namespace="http://youcompany.com/schemas/LocalServer")]
        public class Relationship
        {
            public string type { get; set; }
        }
        public string Name { get; set; }
        public Relationship Relate = new Relationship();
    }
