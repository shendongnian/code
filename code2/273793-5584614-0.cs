    public void Foo(IDictionary<T, IEnumerable<U>> bar)
    {
        T key = GetKeyFromSomewhere();
        bar[key] = new U[10]; // Create an array
    }
