    public static class MethodBaseExtensions
    {
        public static Type GetReturnType(this MethodBase method)
        {
            if (method is MethodInfo info)
                return info.ReturnType;
            if (method is ConstructorInfo ctor)
                return typeof(void);
            throw new ArgumentException($"Argument {nameof(method)} has unsupported type {method.GetType()}.");
        }
    }
