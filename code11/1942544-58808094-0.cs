    public interface IRemository<TEntity> {
        IEnumerable<TEntity> GetAll();
        
        //...
    }
    public class C {
        public int Id { get; }
    }
