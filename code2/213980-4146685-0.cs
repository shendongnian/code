    public static void Insert<T>(this IList<T> list, IList<T> items)
    {
        var attributes = typeof(T).GetCustomAttributes(typeof(InsertableAttribute), true);
        if (attributes.Length == 0)
            throw new ArgumentException("T does not have attribute InsertableAttribute");
        /// Logic.
    }
