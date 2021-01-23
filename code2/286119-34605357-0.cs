    public static class ISupportInitializeHelper
    {
        const string BEGIN_INIT = "System.ComponentModel.ISupportInitialize.BeginInit",
                     END_INIT   = "System.ComponentModel.ISupportInitialize.EndInit";
        public static void InvokeBaseBeginInit<T>(this T obj)
            where T : ISupportInitialize
        {
            var baseType   = typeof(T).BaseType;
            var methodInfo = GetBeginInitMethodInfo(baseType);
            if (methodInfo != null)
                methodInfo.Invoke(obj, null);
        }
        static Dictionary<Type, MethodInfo> s_beginInitCache = new Dictionary<Type, MethodInfo>();
        private static MethodInfo GetBeginInitMethodInfo(Type type)
        {
            MethodInfo methodInfo;
            if (!s_beginInitCache.TryGetValue(type, out methodInfo))
            {
                methodInfo = type.GetMethod(BEGIN_INIT,
                                            BindingFlags.NonPublic |
                                            BindingFlags.Instance);
                s_beginInitCache[type] = methodInfo;
            }
            return methodInfo;
        }
        public static void InvokeBaseEndInit<T>(this T obj)
            where T : ISupportInitialize
        {
            var baseType   = typeof(T).BaseType;
            var methodInfo = GetEndInitMethodInfo(baseType);
            if (methodInfo != null)
                methodInfo.Invoke(obj, null);
        }
        static Dictionary<Type, MethodInfo> s_endInitCache = new Dictionary<Type, MethodInfo>();
        private static MethodInfo GetEndInitMethodInfo(Type type)
        {
            MethodInfo methodInfo;
            if (!s_endInitCache.TryGetValue(type, out methodInfo))
            {
                methodInfo = type.GetMethod(END_INIT,
                                            BindingFlags.NonPublic |
                                            BindingFlags.Instance);
                s_endInitCache[type] = methodInfo;
            }
            return methodInfo;
        }
    }
