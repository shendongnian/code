    bool shouldSkipNext = false;
    for (int i = 0; i < gridview.Rows.Count - 1; i++)
    {
        if (shouldSkipNext)
        {
            shouldSkipNext = false;
            continue;
        }
        // some operation
        shouldSkipNext = aFunction(param1, param2);
    }
    public bool aFunction(param1,param2)
    {
        if (abc)
        {
            return true;
        }
        // Other stuff
        return false;
    }
