    public sealed class MyTestFixture
    {
        private readonly ILogger<MyClass> _logger;
        public MyTestFixture(ITestOuputHelper helper)
        {
            _logger = helper.BuildLoggerFor<MyClass>();
        }
        [Fact]
        public void FooBar()
        {
            var myClass = new MyClass(_logger);
            myClass.WizzBang();
        }
    }
