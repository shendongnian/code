    public void Answer<T>(List<Guid> ids)
    {
        var stack = new ConcurrentStack<T>();
        Parallel.ForEach(ids, (id) =>
        {
            T value = GetData<T>(id);
            stack.Push(value);
        });
        Parallel.For(0, ids.Count, (i) =>
        {
            T item;
            while (!stack.TryPop(out item))
            {
                // sleep
            }
            Process(item);
        });
    }
