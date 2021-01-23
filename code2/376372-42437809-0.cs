    public static class TypeSize
    {
        public static int GetSize<T>(this T value)
        {
            if (typeof(T).IsArray)
            {
                var elementSize = GetTypeSize(typeof(T).GetElementType());
                var length = (value as Array)?.GetLength(0);
                return length.GetValueOrDefault(0) * elementSize;
            }
            return GetTypeSize(typeof(T));
        }
        static ConcurrentDictionary<Type, int> _cache = new ConcurrentDictionary<Type, int>();
        static int GetTypeSize(Type type)
        {
            return _cache.GetOrAdd(type, _ =>
            {
                var dm = new DynamicMethod("SizeOfType", typeof(int), new Type[] { });
                ILGenerator il = dm.GetILGenerator();
                il.Emit(OpCodes.Sizeof, _);
                il.Emit(OpCodes.Ret);
                return (int)dm.Invoke(null, null);
            });
        }
    }
