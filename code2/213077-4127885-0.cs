    [Serializable]
    public class FooData
    {
    }
    
    public class Foo
    {
        private FooData data = new FooData();
        public IBar Bar { get; private set; }
        public FooData Data { get; set; }
        public Foo(IBar bar)
        {
        }
    }
