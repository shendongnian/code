    public class Foo
    {
        public event EventHandler<PersistDataEventArgs> OnPersistData;
        // somewhere in the implementation we call OnPersistData(this, new PersistDataEventArgs(data))
    }
