        [TestMethod]
        public void SomeControllerTest()
        {
            StructureMap.ObjectFactory.Inject(
               typeof(IProjectRepository),
               new MockProjectRepository());
            // ... do some test of your controller with the mock
        }
