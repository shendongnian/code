    public class Company
    {
        public string Name { get; set; }        
        public IEnumerable<Relationship>
        {
            get { ... }
        }
    }
    
    public class Relationship
    {
        public RelationshipType { get; set; }
        public Company { get; set; }
    }
    
    public enum RelationshipType
    {
        Other,
        Debtor,
        Creditor,
        Lead,
    }
