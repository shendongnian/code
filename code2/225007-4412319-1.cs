    class MyMonad<T>
    {
        public static MyMonad<TOut> Bind<TIn, TOut>(MyMonad<TIn>, Func<TIn, MyMonad<TOut>>) { ... }
        public MyMonad(T t) { ... }
    }
