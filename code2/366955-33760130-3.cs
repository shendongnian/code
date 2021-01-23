    public class SpecificCtorServiceDecorator : IService
    {
        private readonly IService _decorated;
        public SpecificCtorServiceDecorator(ILogger logger)
        {
            _decorated = new Service(logger);
        }
        public void DoSomething()
        {
            _decorated.DoSomething();
        }
    }
