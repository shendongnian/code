    List<string> copy = new List<string>(list.Count - indexesToDelete.Count);
    for (int index = 0; index < list.Count; index++)
    {
        if (!indexesToDelete.Contains(index))
            copy.Add(list[index]);
    }
    list = copy;
