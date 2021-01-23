    // Make the property return a Task<T>
    public Task<IEnumerable> MyList
    {
        get
        {
             // Just call the method
             return MyAsyncMethod();
        }
    }
