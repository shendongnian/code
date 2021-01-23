    private abstract class AbstractFoo
    {
        public List<object> Objects { get; private set; }
        public List<object> Load();
        public abstract void Save(List<object> data);
        // add common functionality
    }
    private class ConcreteFoo : AbstractFoo
    {
        public override List<object> Load()
        {
            // do specific stuff
        }
        public override void Save(List<object> data)
        {
            // do specific stuff
        }
    }
