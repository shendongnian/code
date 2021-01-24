    public class SomeService : Service
    {
        private IHelper helper;
        public SomeService(IHelper helper)
        {
            this.helper = helper;
        }
        public object Get(Request req)
        {
            var somethingFromHelper = helper.GetSomething();
            // ... etc ...
        }
    }
