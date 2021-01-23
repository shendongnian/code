    public static class New<T> where T : new()
    {
        public static readonly Func<T> Instance = Expression.Lambda<Func<T>>
                                                  (
                                                   Expression.New(typeof(T))
                                                  ).Compile();
    }
