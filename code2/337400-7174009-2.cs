    void MethodA()
    {
        lock(_lock)
        {
            // ...
            MethodB();
        }
    }
    void MethodB()
    {
        lock(_lock)
        {
            // ...
        }
    }
