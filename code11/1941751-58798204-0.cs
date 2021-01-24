    /// <summary>
    /// Abstraction of the Entity
    /// </summary>
    public interface IEntity
    {
        object Id { get; set; }        
    }
    /// <summary>
    /// Base class for IDs
    /// </summary>
    public abstract class Entity<T>: IEntity where T: struct
    {        
        public T Id { get; set; }
        object IEntity.Id
        {
            get { return Id; }
            set {                
                Id = (T)value;
            }
        }
    }
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntity, new()
    { 
        // The code is omitted for the brevity
    }
