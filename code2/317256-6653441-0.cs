    public abstract class Entity : IPersistable
    {
        public virtual int Id { get; set; }
    }
    
    public interface IPersistable
    {
    }
