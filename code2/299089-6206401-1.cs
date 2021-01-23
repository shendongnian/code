    public abstract class GenericAccess<TEntity> where TEntity : IEntity, new()
    {
        public static IList<TEntity> GetObjectListFromArray(int[] IDs)
        {
            return IDs.Select(id => new TEntity { Id = id }).ToList();
        }
    }
    
    public class Doors : GenericAccess<DoorEntity>
    {
    
    }
    
    public class DoorEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public interface IEntity
    {
        int Id { get; set; }
        string Name { get; set; }
    }
