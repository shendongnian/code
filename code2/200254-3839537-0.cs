    List<int> doubles = new List<int>();
    Dictionary<int, bool> seenBefore = new Dictionary<int, bool>();
    
    foreach(int i in list)
    {
        try
        {
            seenBefore.Add(i, true);
        }
        catch (ArgumentException)
        {
            doubles.Add(i);
        }
    }
    
    return doubles;
