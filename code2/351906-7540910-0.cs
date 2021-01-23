    public interface IFooEvents
    {
        event BaseClass.FooEventHandler Foo;
        event BaseClass.BarEventHandler Bar;
        event BaseClass.BazEventHandler Baz;
    }
    internal class PrivateObject : IFooEvents
    {
        public event BaseClass.FooEventHandler Foo;
        public event BaseClass.BarEventHandler Bar;
        public event BaseClass.BazEventHandler Baz;
        public void ChangeFoo(string foo)
        {
            if (Foo != null)
            {
                Foo(foo);
            }
        }
    }
    public abstract class BaseClass : IFooEvents
    {
        public delegate void BarEventHandler(string bar);
        public delegate void BazEventHandler(string baz);
        public delegate void FooEventHandler(string foo);
        private IFooEvents _fooEvents;
        public event FooEventHandler Foo
        {
            add { _fooEvents.Foo += value; }
            remove { _fooEvents.Foo -= value; }
        }
        public event BarEventHandler Bar
        {
            add { _fooEvents.Bar += value; }
            remove { _fooEvents.Bar -= value; }
        }
        public event BazEventHandler Baz
        {
            add { _fooEvents.Baz += value; }
            remove { _fooEvents.Baz -= value; }
        }
        protected void RegisterIFooEvents(IFooEvents fooEvents)
        {
            _fooEvents = fooEvents;
        }
    }
    public class FirstClass : BaseClass
    {
        private readonly PrivateObject _privateObject;
        public FirstClass()
        {
            _privateObject = new PrivateObject();
            RegisterIFooEvents(_privateObject);
        }
        public void ChangeFoo(string foo)
        {
            _privateObject.ChangeFoo(foo);
        }
    }
