    public static class Null
    {
        public static T? For<T>() where T : struct
        {
            return default(T?);
        }
    }
