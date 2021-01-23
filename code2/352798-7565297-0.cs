    Dictionary<string, string> set = new Dictionary<string, string>();
    foreach (string item in listA)
    {
        set.Add(item, item);
    }
    foreach (string item in listB)
    {
        if (!set.ContainsKey(item))
        {
            //Enable particular control
        }
    }
