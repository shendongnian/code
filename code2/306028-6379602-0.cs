        public static class TypeFactory<T>
    {
        private static Func<int, int, T> Func { get; set; }
        static TypeFactory()
        {
            TypeFactory<Type1>.Func = (a, b) => new Type1(a, b);
            TypeFactory<Type2>.Func = (a, b) => new Type2(a, b);
        }
        public static T Create(int a, int b)
        {
            return Func(a, b);
        }
    }
