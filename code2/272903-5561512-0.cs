    List<string> toRemove = new List<string>();
    foreach (string item in list)
    {
        if (item == "two")
        {
            toRemove.Add(item);
        }
    }
    foreach(string item in toRemove)
    {
        list.Remove(item);
    }
