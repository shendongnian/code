    public interface IDataPersistor
    {
        void PersistData(Data data);
    }
    public class Foo
    {
        private IDataPersistor Persistor { get; set; }
        public Foo(IDataPersistor persistor)
        {
            Persistor = persistor;
        }
        // somewhere in the implementation we call Persistor.PersistData(data);
        
    }
