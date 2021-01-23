    public interface IRepository
    {
        void Foo();
    }
    public interface IRepository<T> : IRepository
    {
    }
    public class Repository<T> : IRepository<T>
    {
        public void Foo()
        {
        }
    }
