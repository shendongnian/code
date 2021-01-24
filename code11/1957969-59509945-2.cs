    public class ProcessCompletedIntegrationEventHandler: 
        IIntegrationEventHandler<ProcessCompletedIntegrationEvent>
    {
        public Task Handle(ProcessCompletedIntegrationEvent @event)
        {
            // Standard handler logic goes here
        }
    }
    
    public class TestEventHandler: 
        IIntegrationEventHandler<ProcessCompletedIntegrationEvent>
    {
        private readonly IIntegrationEventHandler<ProcessCompletedIntegrationEvent> realHandler;
        public bool HandlerCalled { get; private set; }
    
        //This will be injected by the DI container
        public TestEventHandler(ProcessCompletedIntegrationEventHandler realHandler)
        {
            this.realHandler = realHandler;
        }
    
        public Task Handle(ProcessCompletedIntegrationEvent @event)
        {
            HandlerCalled = true;
            realHandler.Handle(@event)
        }
    }
    
    //here you would setup the Depdendency Injection and rest of he stuff regarding your services..
    // this will depend on what you are using, ASP.NET Core or something else
    public class BaseIntegrationTests
    {
        protected IServiceCollection container;
    
        public BaseIntegrationTests()
        {
            //some setup code here.....
            RegisterDependencies();
        }
    
        //Register dependencies for DI Container
        private void RegisterDependencies()
        {
            container.AddScoped(ProcessCompletedIntegrationEventHandler, TestEventHandler);
    
            //other registrations here ......
        }
    
        protected void RegisterTestEventHandlerInstance(TestEventHandler testEventHandler)
        {
            container.AddSingleton(IIntegrationEventHandler<ProcessCompletedIntegrationEvent>, testEventHandler);
        }
    }
    
    public class IntegrationTests : BaseIntegrationTests
    {
        private readonly TestEventHandler testEventHandler;
    
        public IntegrationTests()
        {
            //you could move this code here to the test if you want to use a different instance per test
            testEventHandler = new TestEventHandler();
            RegisterTestEventHandlerInstance(testEventHandler);
        }
    
        [Fact]
        public async Task IfReceivesAndPublishesEvents()
        {
            // Arrange
            _rabbitMQBus.Subscribe<
                  ProcessCompletedIntegrationEvent,
                  ProcessCompletedIntegrationEventHandler>();
    
            // You would need to register dependecies if you use DI here
            // or in some central TestFixture class or similar
            // you would do something like
    
            //Check if the handler is not called yet, since the event has not been published
            Assert.False(testEventHandler.HandlerCalled);
    
            // Act
            Eventbus.Publish(new ProcessIntegrationEvent(name: "test"));
    
            // Assert 
            //if handler is called the flag should be true
            Assert.True(testEventHandler.HandlerCalled);
        }
    }
