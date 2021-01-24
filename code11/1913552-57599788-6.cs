    [TestClass]
    public class ServiceRegistrationTests
    {
        [DataTestMethod]
        [DataRow("MessageOne")]
        [DataRow("MessageTwo")]
        public void FactoryResolvesMessageHandlers(string messageType)
        {
            var provider = GetServiceProvider();
            var factory = provider.GetService<IMessageHandlerFactory>();
            var handler = factory.GetHandler(messageType);
            Assert.IsNotNull(handler);
        }
        private IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddMessageHandlers();
            return services.BuildServiceProvider();
        }
    }
