    [XmlInclude(typeof(Relationship))]
    public class SiteServer
    {
        [XmlRoot("SiteServerRelationship", Namespace = "http://example.com/schemas/SiteServerRelationship")] 
        public class Relationship
        {
            public string type { get; set; }
        }
        public string Name { get; set; }
        [XmlElement("SiteServerRelationship", Namespace="http://example.com/schemas/SiteServerRelationship")]       
        public Relationship Relate = new Relationship();
    }
    
    [XmlInclude(typeof(Relationship))]    
    public class LocalServer
    {
        [XmlRoot("LocalServerRelationship", Namespace = "http://example.com/schemas/LocalServerRelationship")] 
        public class Relationship
        {
            public string type { get; set; }
        }
        public string Name { get; set; }
        [XmlElement("LocalServerRelationship", Namespace="http://example.com/schemas/LocalServerRelationship")] 
        public Relationship Relate = new Relationship();
    }
