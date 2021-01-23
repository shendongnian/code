    interface IFoo<T>
    {
        void Add(T t);
        void Delete(string str);
        IEnumerable<T> GetInfo(string name);
    }
