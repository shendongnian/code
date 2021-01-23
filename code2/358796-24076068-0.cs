    public static class Helper
    {
        public static string GetName<T>()
        {
            Type type = typeof(T);
            Type[] genericArguments = type.GetGenericArguments();
            return string.Format("{0}<{1}>", type.Name, string.Join(",", genericArguments.Select(arg => arg.Name)));
        }
    }
