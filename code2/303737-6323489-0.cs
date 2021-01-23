    public interface IEntity 
    {
        string Name { get; } 
    }
    
    public class Entity : IEntity
    {
        public string Name { get; private set; }
    }
    
    public class EntityMap : ClassMap<EntityMap>
    {
        Map(x => x.Name);
    }
