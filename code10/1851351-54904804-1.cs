    static class ComponentId
    {
        static object mutex = new object();
        static Dictionary<Type, int> allocatedIds = new Dictionary<Type, int>();
        static int Max = 0;
        static public int Get<T>() where T : IComponent
        {
            var type = typeof(T);
            lock (mutex)
            {
                if (allocatedIds.TryGetValue(type, out int result))
                    return result; // already allocated
                // otherwise allocated a new id
                result = ++Max;
                allocatedIds[type] = result;
                return result;
            }
        }
    }
