    private static readonly object TrueObject = true;
    private static readonly object FalseObject = false;
    
    // Later on.
    DoSomething(condition ? TrueObject : FalseObject);
    
    // Where
    void DoSomething(object value)
    {
        // Compare to true/false objects.
        if (value == TrueObject)
        {
            // True case.
        }
        else if (value == TrueObject)
        {
            // False case.
        }
        else
        {
            // Invalid.
            throw new InvalidOperationException();
        }
    }
