    public interface IVisitableObject { }
    public interface IGenericComponent<T> where T : IVisitableObject
    {
        void Update(T msg);
    }
    abstract class Dispatcher
    {
        protected Dispatcher() { }
        public abstract void Dispatch(IVisitableObject message, IEnumerable<object> subscribers);
        static Dictionary<Type, Dispatcher> dispatchers = new Dictionary<Type, Dispatcher>();
        static Dispatcher GetDispatcherFor(IVisitableObject message)
        {
            Type type = message.GetType();
            if (!dispatchers.ContainsKey(type))
            {
                Type closedType = typeof(Dispatcher<>).MakeGenericType(message.GetType());
                object dispatcher = Activator.CreateInstance(closedType);
                dispatchers[type] = (Dispatcher)dispatcher;
            }
            return dispatchers[type];
        }
    }
    class Dispatcher<T> : Dispatcher where T : IVisitableObject
    {
        public override void Dispatch(IVisitableObject message, IEnumerable<object> subscribers)
        {
            var msg = (T)message;
            foreach (var subscriber in subscribers.OfType<IGenericComponent<T>>())
            {
                subscriber.Update(msg);
            }
        }
    }
