    public abstract class GenericAccess<TEntity> where TEntity : Entity, new()
    {
        public static IList<TEntity> GetObjectListFromArray(int[] IDs)
        {
            return IDs.Select(id => new TEntity { Id = id }).ToList();
        }
    }
    public class Doors : GenericAccess<DoorEntity>
    {
    }
    public class DoorEntity : Entity
    {
    }
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
