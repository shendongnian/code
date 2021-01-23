    interface IMessage {}
    class Foo : IMessage {}
    interface Handler<T> where T : IMessage
    {
        void ProcessMessage(T obj);
    }
    class FooHandler : Handler<Foo>
    {
        public void ProcessMessage(Foo foo) {}
    }
    class Program
    {
        static readonly Dictionary<Type, Action<object>> handlers = new Dictionary<Type, Action<object>>();
        static void AddHandler<T>(Handler<T> handler) where T : IMessage
        {
            handlers.Add(typeof(T), m => handler.ProcessMessage((T)m));
        }
        static void ProcessMessage(object message)
        {
            var handler = handlers[message.GetType()];
            handler(message);
        }
        public static IEnumerable<Type> GetAllTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
        }
        public static IEnumerable<Type> GetDerivedFrom<T>()
        {
            return GetAllTypes().Where(t => IsDerivedFrom(t, typeof(T)));
        }
        static bool IsDerivedFrom(Type t, Type parent)
        {
            return parent.IsAssignableFrom(t) && t!=parent;
        }
        static void Main()
        {
            var handlerTypes =
                from handlerBaseType in GetDerivedFrom<IMessage>().Select(t => typeof(Handler<>).MakeGenericType(t))
                select GetAllTypes().FirstOrDefault(t => IsDerivedFrom(t, handlerBaseType))
                into handlerType
                where handlerType!=null
                select Activator.CreateInstance(handlerType);
            foreach (object handler in handlerTypes)
            {
                AddHandler((dynamic)handler);
                Console.WriteLine("Registered {0}.", handler.GetType());
            }
        }
    }
