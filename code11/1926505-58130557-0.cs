    if (cachedDelegate == null)
    {
        cachedDelegate = new Func<int, int>(GeneratedClass.CachedInstance.Method);
    }
    cachedDelegate.Invoke(arg);
