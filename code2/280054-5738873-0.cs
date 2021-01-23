    /// <summary>
    /// Class Foo requires T to be type that can be null. E.g., a class or a Nullable&lt;T&gt;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Foo<T>
    {
        public Foo()
        {
            if (default(T) != null)
                throw new InvalidOperationException(string.Format("Type {0} is not valid", typeof(T)));
        }
        // other members here
    }
