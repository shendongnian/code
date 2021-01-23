    [Serializable]
        [XmlInclude(typeof(Relationship))]    
        public class SiteServer
        {
            [XmlRoot("SiteServerRelationship", Namespace = "http://sample.com/schemas/SiteServerRelationship")] 
            public class Relationship
            {
                public string type { get; set; }
    
            }
    
            public string Name { get; set; }
    
           [XmlElement("SiteServerRelationship", Namespace="http://sample.com/schemas/SiteServerRelationship")]       
            public Relationship Relate = new Relationship();
    
        }
    
        [Serializable]
        [XmlInclude(typeof(Relationship))]    
        public class LocalServer
        {
            [XmlRoot("LocalServerRelationship", Namespace = "http://sample.com/schemas/LocalServerRelationship")] 
            public class Relationship
            {
                public string type { get; set; }
    
            }
    
            public string Name { get; set; }
    
            [XmlElement("LocalServerRelationship", Namespace="http://sample.com/schemas/LocalServerRelationship")] 
            public Relationship Relate = new Relationship();
    
        }
