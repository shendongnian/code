    namespace Extensions
    {
        /// <summary> Useful in number of places that return an empty byte array to avoid unnecessary memory allocation. </summary>
        public static class Array<T>
        {
            public static readonly T[] Empty = new T[0];
        }
    }
