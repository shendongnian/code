    public static class NullableExtensions
    {
        // Note that action has non-nullable argument
        public static void Invoke<T>(this Nullable<T> nullable, Action<T> action)
            where T: struct
        {
            if (nullable.HasValue)
                action(nullable.Value);
        }
    }
