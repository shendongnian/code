    public static class Factory<C> where C : IBaseClass, new()
    {
        private static object initialData;
        private static Dictionary<IKey, Triple<EventHandlerTypes, int, Action<object, SharedEventArgs>>> handlers = new Dictionary<IKey, Triple<EventHandlerTypes, int, Action<object, SharedEventArgs>>>();
        private static Dictionary<IKey, object> data = new Dictionary<IKey, object>();
        static Factory()
        {
            C newClass = new C();
            newClass.RegisterSharedData(registerSharedData);
        }
        public static void Init<IT>(IT initData)
        {
            initialData = initData;
        }
        public static Dt[] GetData<Dt>()
        {
            var dataList = from d in data where d.Key.GetKeyType() == typeof(Dt) select d.Value;
            return dataList.Cast<Dt>().ToArray();
        }
        private static void registerSharedData(IKey key, object value)
        {
            data.Add(key, value);
        }
        public static C Create(int? group)
        {
            C newClass = new C();
            newClass.RegisterSharedHandlers(group, registerSharedHandlers);
            Factory<C>.Call(EventHandlerTypes.SetInitialData, null, initialData);
            return newClass;
        }
        private static void registerSharedHandlers(IKey subscriber, int? group, EventHandlerTypes type, Action<object, SharedEventArgs> handler)
        {
            handlers.Add(subscriber, new Triple<EventHandlerTypes, int, Action<object, SharedEventArgs>>(type, group ?? -1, handler));
        }
        public static void Call<N>(EventHandlerTypes type, int? group, N data)
        {
            Call<N>(null, type, group, data);
        }
        public static void Call<N>(object sender, EventHandlerTypes type, int? group, N data)
        {
            SharedEventArgs arg = new SharedEventArgs(data);
            var events = from h in handlers where h.Value.First == type && (!@group.HasValue || h.Value.Second == (int)@group) select h.Value.Third;
            foreach (var ev in events)
            {
                ev(sender, arg);
            }
        }
    }
