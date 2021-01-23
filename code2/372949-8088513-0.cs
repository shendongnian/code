    public string SomeValue
    {
        get
        {
            // Note: Not thread safe...
            if(someValue == null)
            {
                someValue = InitializeSomeValue(); // Todo: Implement
            }
            return someValue;
        }
    }
