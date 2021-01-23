    [TestClass]
    public class SetterInjectionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IServiceB>().ImplementedBy<ServiceB>());
            container.Register(Component.For<IServiceA>().ImplementedBy<ServiceA>());
            var serviceA = container.Resolve<IServiceA>();
            Assert.IsTrue(serviceA.IsPropertyInjected());
        }
    }
    public class ServiceA : IServiceA
    {
        public IServiceB B { get; set; }
        public bool IsPropertyInjected()
        {
            return B != null;
        }
    }
    public interface IServiceA
    {
        bool IsPropertyInjected();
    }
    public class ServiceB : IServiceB{}
    public interface IServiceB{}
