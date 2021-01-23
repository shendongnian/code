    public class SomeEntity
    {
        [Key]
        public int Id {get;set;}
        public string Name {get;set;}
    }
    
    public class EntityProperty
    {
        // What is PK here? Something like:
        [Key]
        public int Id {get;set;}
        // EntityId is FK
        public int EntityId {get;set;}
        
        // Navigation property
        [ForeignKey("EntityId")]
        public SomeEntity LinkedEntity {get;set;}
        
        public string Name {get;set;}
    }
