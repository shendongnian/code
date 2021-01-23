    public void DoSomething(Action<T> action)
    {
        lock (...)
        {
            // Call action on each element in here
        }
    }
