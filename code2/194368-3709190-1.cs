    int x;
    [object] e;
    try
    {
        e = collection.GetEnumerator();
        while (e.MoveNext())
        {
            x = [cast if possible]e.Current;
        }
    }
    finally
    {
        [dispose of e if necessary]
    }
