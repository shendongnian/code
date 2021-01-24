    List<int> indexes = new List<int>();
    for (int i = 0; i < items.Count; i++)
    {
        string temp = items[i];
        indexes.Clear();
        while (temp.Length <= match.Length && temp == match.Substring(0, temp.Length))
        {
            indexes.Add(i + 1); // example was given using 1-based
            temp += items[++i];
        }
        if (temp == match)
        {
            break; // at this point, indexes contains the values sought
        }
    }
