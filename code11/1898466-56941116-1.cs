    public class DiscreteSingletonTests
    {
        [TestMethod]
        public void ResolvesDiscreteSingletons()
        {
            var serviceProvider = GetServiceProvider();
            var resolvedA1 = serviceProvider.GetService<IServiceA>();
            var resolvedA2 = serviceProvider.GetService<IServiceA>();
            var resolvedB1 = serviceProvider.GetService<IServiceB>();
            var resolvedB2 = serviceProvider.GetService<IServiceB>();
            Assert.AreSame(resolvedA1.SharedService, resolvedA2.SharedService);
            Assert.AreSame(resolvedB1.SharedService, resolvedB2.SharedService);
            Assert.AreNotSame(resolvedA1.SharedService, resolvedB1.SharedService);
        }
        private IServiceProvider GetServiceProvider()
        {
            // What goes here?
        }
    }
