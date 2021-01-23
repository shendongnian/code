    IBindingInNamedWithOrOnSyntax<T> WhenCachingModeIs<T>(
        this IBindingWhenSyntax<T> syntax,
        CacheMode cacheMode)
    {
        return syntax.When(_ => GetTheCurrentCacheMode() == cacheMode);
    }
    Bind<IRepo>().To<CachedRepo>().WhenCachingModeIs(CacheMode.Cached);
    Bind<IRepo>().To<Repo>().WhenCachingModeIs(CacheMode.NotCached);
