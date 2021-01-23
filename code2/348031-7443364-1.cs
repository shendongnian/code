    public T Resolve<T>()
        where T:class {
            if (typeof(T).IsAssignableFrom(typeof(Something)))
                return new Something(Resolve<ISomethingElse>()) as T;
            ...
    }
