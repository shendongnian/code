    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            Id(n => n.Id);
        }
    }
