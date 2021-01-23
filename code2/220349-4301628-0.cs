    static class ReflectionMethodCache<TClass>
    {
        /// <summary>
        /// this field gets a different slot for every usage of this generic static class
        /// http://stackoverflow.com/questions/2685046/uses-for-static-generic-classes
        /// </summary>
        private static readonly ConcurrentDictionary<BindingFlags, IList<RuntimeMethodHandle>> MethodHandles;
            
        static ReflectionMethodCache()
        {
            MethodHandles = new ConcurrentDictionary<BindingFlags, IList<RuntimeMethodHandle>>(2, 5);
        }
        
        public static IEnumerable<RuntimeMethodHandle> GetCallableMethods(BindingFlags bindingFlags)
        {
            return MethodHandles.GetOrAdd(bindingFlags, RuntimeMethodHandles);
        }
        public static List<RuntimeMethodHandle> RuntimeMethodHandles(BindingFlags bindingFlags)
        {
            return (from methodInfo in typeof (TClass).GetMethods(bindingFlags)
                    from CallableAttribute a in
                        methodInfo.GetCustomAttributes(typeof (CallableAttribute), false)
                    where a.Callable
                    select methodInfo.MethodHandle).ToList();
        }
    }
    public class DynamicCallableMethodTable<TClass, THandle>
        where THandle : class
    {
        private readonly IDictionary<string, THandle> _table = new Dictionary<string, THandle>();
        public DynamicCallableMethodTable(TClass instance, Func<string, string> nameMangler,
                                 BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance)
        {
            var callableMethods = ReflectionMethodCache<TClass>.GetCallableMethods(bindingFlags);
            foreach (MethodInfo methodInfo in callableMethods.Select(MethodBase.GetMethodFromHandle))
            {
                _table[nameMangler(methodInfo.Name)] = methodInfo.CastToDelegate<THandle>(instance);
            }
        }
        public bool TryGetMethod(string key, out THandle handle)
        {
            return _table.TryGetValue(key, out handle);
        }
    }
    public static class MethodEx
    {
        public static TDelegate CastToDelegate<TDelegate>(this MethodInfo method, object receiver)
            where TDelegate : class
        {
            return Delegate.CreateDelegate(typeof(TDelegate), receiver, method, true) as TDelegate;
        }
    }
