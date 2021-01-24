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
            // Make sure we're resolving multiple instances of each. 
            // That way we'll know that the "discrete" singleton is really working.
            Assert.AreNotSame(resolvedA1, resolvedA2);
            Assert.AreNotSame(resolvedB1, resolvedB2);
            // Make sure that all instances of ServiceA or ServiceB receive
            // the same instance of SharedService.
            Assert.AreSame(resolvedA1.SharedService, resolvedA2.SharedService);
            Assert.AreSame(resolvedB1.SharedService, resolvedB2.SharedService);
            // ServiceA and ServiceB are not getting the same instance of SharedService.
            Assert.AreNotSame(resolvedA1.SharedService, resolvedB1.SharedService);
        }
        private IServiceProvider GetServiceProvider()
        {
            // This is the important part.
            // What goes here?
            // How can we register our services in such a way
            // that the unit test will pass?
        }
    }
