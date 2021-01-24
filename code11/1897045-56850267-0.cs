    public interface IProcess
    {
        void Process(string id);
    }
    
    
    public interface IProcess<T> : IProcess where T : class
    {
    }
