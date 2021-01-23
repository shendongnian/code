    public void DoSomething(IEnumerable<string> list)
    {
        bool isFirstItem = true;
        foreach (var item in list)
        {
            if (isFirstItem)
            {
                isFirstItem = false;
                // ...
            }
            // ...
        }
    }
