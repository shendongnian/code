    bool isEmpty = true;
    if (items != null)
    {
        foreach (var item in items)
        {
            isEmpty = false;
            DoSomething(item);
        }
    }
    if (isEmpty)
    {
        DoSomethingElse();
    }
