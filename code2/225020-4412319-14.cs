    class MyMonad<T>
    {
        public MyMonad<TOut> Bind<TOut>(MyMonad<T>, Func<T, MyMonad<TOut>>) { ... }
        public MyMonad(T t) { ... }
    }
