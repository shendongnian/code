    public static class ObjectExt
    {
        public static T2 Coalesce<T1, T2>(
             this T1 obj, Func<T1, T2> projection, T2 defaultValue)
        {
            if (obj == null)
                return defaultValue;
            return projection(obj);
        }
    }
