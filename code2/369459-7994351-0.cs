    public interface IFactory<T>
    {    
        IEnumerable<T> GetAll();
        T GetOne(int Id);
    }
