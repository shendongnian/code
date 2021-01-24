    public delegate A Reader<A>(IAlgorithm env);
    public static class Reader
    {
        public static Reader<A> Pure<A>(A value) =>
            _ => value;
        public static Reader<B> Bind<A, B>(this Reader<A> ma, Func<A, Reader<B>> f) => env =>
            f(ma(env))(env);
        public static Reader<B> Map<A, B>(this Reader<A> ma, Func<A, B> f) =>
            Bind(ma, a => Pure(f(a)));
        public static Reader<B> Select<A, B>(this Reader<A> ma, Func<A, B> f) =>
            Map(ma, f);
        public static Reader<C> SelectMany<A, B, C>(this Reader<A> ma, Func<A, Reader<B>> bind, Func<A, B, C> project) =>
            Bind(ma, a => Map(bind(a), b => project(a, b)));
        public static Reader<IAlgorithm> Ask =>
            env => env;
    }
