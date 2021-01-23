    public class Service : IService
    {
        private readonly ILogger _logger;
        public Service(ILogger logger)
            : this(logger, SomeDefaultListOfThings())
        {
        }
        // Let's say Windsor is calling this ctor for some reason (ArrayResolver?)
        public Service(ILogger logger, IEnumerable<object> emptyArrayFromWindsor)
        {
            _logger = logger;
            PutTheItemsSomewhere(emptyArrayFromWindsor);
        }
        public void DoSomething()
        {
            // Something that relies on the list of items...
        }
    }
