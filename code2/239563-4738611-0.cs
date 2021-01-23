    public class RepositoryFactory
    {
        public static T Resovle<T>(string connection) where T: IRepository
        {
            IRepository instance = new Repository(connection);
            return (T)instance;
        }
    
        private class Repository : IFullRepository
        {
            private string _connection;
    
            public Repository(string connection)
            {
                _connection = connection;
            }
    
            public object Get(int id)
            {
                // select
            }
    
            public void Save(object o)
            {
                // upate
            }
    
            public void Create(object o)
            {
                // create
            }
    
            public void CustomMethodOne()
            {
                // do something specialized
            }
    
            public void CustomMethodTwo()
            {
                // do something specialized
            }
        }
    }
    
    public interface IRepository
    {
        object Get(int id);
        void Save(object o);
        void Create(object o);
    }
    
    public interface IRepositoryProjectOne: IRepository
    {
        void CustomMethodOne();
    }
    
    public interface IRepositoryProjectTwo: IRepository
    {
        void CustomMethodTwo();
    }
    
    public interface IFullRepository: IRepositoryProjectOne, IRepositoryProjectTwo
    {
        
    }
