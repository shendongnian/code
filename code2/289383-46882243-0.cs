    public class BaseClassExplicitInterfaceInvoker<T>
    {
        readonly Dictionary<string, MethodInfo> Cache = new Dictionary<string, MethodInfo>();
        MethodInfo FindMethod(string MethodName)
        {
            if (Cache.TryGetValue(MethodName, out var Result)) return Result;
            var BaseType = typeof(T);
            while (Result == null)
            {
                if ((BaseType = BaseType.BaseType) == typeof(object)) break;
                var Methods = BaseType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                Result = Methods.FirstOrDefault(X => X.IsFinal && X.IsPrivate && (X.Name == MethodName || X.Name.EndsWith("." + MethodName)));
            }
            if (Result != null) Cache.Add(MethodName, Result);
            return Result;
        }
        public void Invoke(T Object, string MethodName, params object[] Parameters) => FindMethod(MethodName).Invoke(Object, Parameters);
        public ReturnType Invoke<ReturnType>(T Object, string MethodName, params object[] Parameters) => (ReturnType)FindMethod(MethodName).Invoke(Object, Parameters);
    }
