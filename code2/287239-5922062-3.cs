    abstract class A
    {
        class SharedType { int x; }
        static Dictionary<Type, SharedType> all_shared;
        protected SharedType Shared;
        A() {
            Type t = GetType();
            if (!all_shared.TryGetValue(t, out Shared) {
                 Shared = new SharedType();
                 all_shared.Add(t, Shared);
            }
        }
    }
