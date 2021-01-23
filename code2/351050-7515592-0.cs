    public IEnumerable GetBoxed(Type type, string param1, string param2)
    {
        return (IEnumerable)this
            .GetType()
            .GetMethod("Get")
            .MakeGenericMethod(type)
            .Invoke(this, new[] { param1, param2 });
    }
