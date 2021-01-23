    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For(typeof (IRepository<>)).Use(typeof(Repository<>));
        }
    }
