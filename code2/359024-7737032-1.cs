    public interface IDataAccessConfiguration
    {
        string Assembly { get; }
        string Type { get; }
    }
    public sealed class DataAccessfactory
    {
        private IDataAccessConfiguration Config { get; set; }
        public DataAccessfactory(IDataAccessConfiguration config)
        {
            this.Config = config;
        }
        public ISomeDataContext GetSomeDataContext()
        {
            return new SomeDataContext(this.Config);
        }
    }
    public class SomeDataContext : ISomeDataContext
    {
        private IDataAccessConfiguration Config { get; set;}
        public SomeDataContext(IDataAccessConfiguration config)
        {
            this.Config = config;
        }
        private DataContext GetDataContext()
        {
            Assembly a = Assembly.Load(this.Config.Assembly);       
            return (DataContext)a.CreateInstance(this.Config.Type);  
        }
    }
