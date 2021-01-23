    public static class InstanceLocator
    {
        static IDictionary<Type, object> _typeFactory = new Dictionary<Type, object>();
        public static void Register<T>(Func<T> builder)
        {
            if (_typeFactory.ContainsKey(typeof(T)))
                _typeFactory[typeof(T)] = builder;
            else
                _typeFactory.Add(typeof(T), builder);
        }
        public static T GetInstance<T>()
        {
            if (_typeFactory.ContainsKey(typeof(T)))
                throw new ArgumentException(string.Format("Type <{0}> not registered in InstanceLocator", typeof(T).Name));
            return ((Func<T>)_typeFactory[typeof(T)])();
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
            InstanceLocator.Register<IClientManager>(() => new RealClientManager());
        }
        public void SomeMethodThatNeedsClientManager()
        {
            var clientManager = InstanceLocator.GetInstance<IClientManager>();
        }
    }
    public class MyTester
    {
        [TestMethod()]
        public void SomeTest()
        {
            var view = new MyView();
            // swap the client manager in the test
            InstanceLocator.Register<IClientManager>(() => new MockClientManager());
            // Asserts
        }
    }
