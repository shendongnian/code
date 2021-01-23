    public class SomeEntity
    {
        public int SomeEntityId {get;set;}
        public string Name {get;set;}
        public ICollection<EntityProperty> EntityProperties {get;set;}
    }
    
    public class EntityProperty
    {
        public int EntityPropertyId {get;set;}
        public string Name {get;set;}
    }
