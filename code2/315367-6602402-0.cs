    // Make the property return a Task<T>
    public Task<IEnumarable> MyList
    {
        get
        {
             // Just call the method
             return MyAsyncMethod();
        }
    }
