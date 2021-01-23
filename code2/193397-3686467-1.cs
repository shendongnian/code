    public class Service<T> : IService<T>
    {
        Repository<T> _repository = new Repository<T>();
        public T Get(int id)
        {
            return _repository.Get<T>(id);
        }
    }
    
    public interface IService<T>
    {
        T Get(int id);
    }
