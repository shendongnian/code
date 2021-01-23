    static void Main()
    {
        var both = Test.A.Include(Test.B);
    }
    enum Test : ulong
    {
        A = 1, B = 2
    }
    public static T Include<T>(this T type, T value) where T : struct
    {
        return DynamicCache<T>.or(type, value);
    }
    static class DynamicCache<T>
    {
        public static readonly Func<T, T, T> or;
        static DynamicCache()
        {
            if(!typeof(T).IsEnum) throw new InvalidOperationException(typeof(T).Name + " is not an enum");
            var dm = new DynamicMethod(typeof(T).Name + "_or", typeof(T), new Type[] { typeof(T), typeof(T) }, typeof(T),true);
            var il = dm.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Or);
            il.Emit(OpCodes.Ret);
            or = (Func<T, T, T>)dm.CreateDelegate(typeof(Func<T, T, T>));
        }
    }
