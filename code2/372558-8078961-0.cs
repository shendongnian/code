    public abstract class Foo : IWithSession
    {
        public IDictionary<string, object> Session { get; private set; }
        protected Foo()
        {
            Session = new Dictionary<string, object>();
        }
        [Session]
        public abstract int Id { get; set; }
    }
