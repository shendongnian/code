    int x = 42;
    Console.WriteLine(Utils.SizeOf(x));    // Output: 4
    // ...
    public static class Utils
    {
        public static int SizeOf<T>(T obj)
        {
            return SizeOfCache<T>.SizeOf;
        }
        private static class SizeOfCache<T>
        {
            public static readonly int SizeOf;
            static SizeOfCache()
            {
                var dm = new DynamicMethod("func", typeof(int),
                                           Type.EmptyTypes, typeof(Utils));
            	ILGenerator il = dm.GetILGenerator();
                il.Emit(OpCodes.Sizeof, typeof(T));
                il.Emit(OpCodes.Ret);
                var func = (Func<int>)dm.CreateDelegate(typeof(Func<int>));
                SizeOf = func();
            }
        }
    }
