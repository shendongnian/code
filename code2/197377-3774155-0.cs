    static void doSomething<T>() where T : Parent
    {
        if (typeof(T) == typeof(Parent))
        {
            T obj = orm.GetObject<T>(criteria);
        }
        else if (typeof(T) == typeof(Child))
        {
            T obj = orm.GetObject<T>(criteria);
        }
    }
