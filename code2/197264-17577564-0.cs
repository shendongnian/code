    GetDictKeyPos(d, "c");
    public int GetDictKeyPos(Dictionary<string, int> d, string key)
    {
        for (int i = 0; i < d.Count; ++i)
        {
            if (d.ElementAt(i).Key == key)
                return i;
        }
        return -1;
    }
