    public interface IRemository<TEntity> {
        IEnumerable<TEntity> GetAll();
        
        //...other members
    }
    public class C {
        public int Id { get; set; }
        //...other members
    }
