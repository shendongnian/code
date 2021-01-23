    public static class MyTypeFactory
    {
        static MyTypeFactory()
        {
            MethodRunner<Type1>.Func = (a, b) => new Type1(a, b);
            MethodRunner<Type2>.Func = (a, b) => new Type2(a, b);
        }
        public static T Create<T>(int a, int b)
        {
            return MethodRunner<T>.Func(a, b);
        }
        
        static class MethodRunner<T>
        {
            public static Func<int, int, T> Func { get; set; }
        }
    }
