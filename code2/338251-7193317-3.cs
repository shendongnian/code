    for (int i = myList.Count - 1; i >= 0; i--)
    {
        // Do processing here, then...
        if (shouldRemoveCondition)
        {
            myList.RemoveAt(i);
        }
    }
