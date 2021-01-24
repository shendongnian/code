    public void Create<T>()
    {
        Type key = typeof(T);
        var foo = new Foo(key.Name);
        IConstants constants = Constants[key];
        foo.InitialHealth = constants.InitialHealth;
        if (constants.MaxTries is int maxTries) { // Only true if MaxTries.HasValue.
                                                    // Converts to int at the same time.
            foo.Add(maxTries);
        }
    }
