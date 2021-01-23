    public abstract class EntityCollection<T> : List<T>
        where T : Entity
    {
        public abstract Repository<T> GetRepository();
    }
    
    public class BookCollection : EntityCollection<Book>
    {
        public override Repository<Book> GetRepository()
        {
            return BookRepository();
        }
    }
