    abstract class A
    {
        class SharedType { int x; }
        static Dictionary<Type, SharedType> all_shared;
        protected SharedType Shared {
            get
            {
                Type t = GetType();
                SharedType result;
                if (!all_shared.TryGetValue(t, out result) {
                     result = new SharedType();
                     all_shared.Add(t, result);
                }
                return result;
            }
        }
    }
