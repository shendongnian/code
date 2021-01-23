    public interface IEntity 
    {
        string Name { get; } 
    }
    
    public class Entity : IEntity
    {
        public string Name { get; private set; }
    }
    
    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            Map(x => x.Name);
        }
    }
