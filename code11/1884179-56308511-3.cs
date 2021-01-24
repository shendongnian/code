    public Func<T,T> MyFunction(Func<T, T> function, int iteration)
    {
        // create a collection with `N = interation` items
        IEnumerable<Func<T,T>> items = Enumerable.Repeat<T>(function.Invoke(), iteration);
        
        // return items
        foreach(Func<T,T> item in items)
        {
            yield return item;
        }
    }
