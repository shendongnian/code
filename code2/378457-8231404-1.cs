    public static class ObjectFactory
    {
        static IDictionary<Type, object> _factory = new Dictionary<Type, object>();
        public static void Register<T>(Func<T> builder)
        {
            if (_factory.ContainsKey(typeof(T)))
                _factory[typeof(T)] = builder;
            else
                _factory.Add(typeof(T), builder);
        }
        public static T GetInstance<T>()
        {
            if (_factory.ContainsKey(typeof(T)))
                throw new ArgumentException(string.Format("Type <{0}> not registered in ObjectFactory", typeof(T).Name));
            return ((Func<T>)_factory[typeof(T)])();
        }
    }
    public interface IClientManager { }
    public class RealClientManager : IClientManager { }
    public class MockClientManager : IClientManager { }
    public class MyView
    {
        public MyView()
        {
            // probably better to do this registry in some sort of application initialization
            ObjectFactory.Register<IClientManager>(() => new RealClientManager());
        }
        public void SomeMethodThatNeedsClientManager()
        {
            var clientManager = ObjectFactory.GetInstance<IClientManager>();
        }
    }
    public class MyTester
    {
        [TestMethod()]
        public void SomeTest()
        {
            var view = new MyView();
            // swap the client manager in the test
            ObjectFactory.Register<IClientManager>(() => new MockClientManager());
            // Asserts
        }
    }
