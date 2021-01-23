    for (int i = 0; i < gridview.Rows.Count - 1; i++)
    {
        // some operation
        if (aFunction(param1, param2))
        {
            continue;
        }
        // Other stuff which will sometimes be skipped
    }
