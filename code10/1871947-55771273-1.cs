    for (int i = Items.Count - 1; i >= 0; i--) // n times
    {
        if (Items[i].Name == name)
        {
            Items.RemoveAt(i); //O(n)
        }
    }
