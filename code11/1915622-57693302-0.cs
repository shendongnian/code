    private int Count(Entry entry)
    {
        HashSet<int> parentIds = new HashSet<int>();
        parentIds.Add(entry.ID);
        int count = 0;
        foreach (Entry e in AllEntries)
        {
            if (parentIds.Contains(e.ParentID))
            {
                count++;
                parentIds.Add(e.ID);
            }
        }
        return count;
    }
