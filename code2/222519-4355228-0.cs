    ulong MakeEntry(int i1, int i2)
    {
        ulong hi = (ulong)Math.Max(i1, i2);
        ulong lo = (ulong)Math.Min(i1, i2);
        return (hi << 32) | lo;
    }
    
    List<ulong> items = new List<ulong>();
    
    void DoSomething()
    {
        // get numbers i1 and i2
        // and add to the list
        items.Add(MakeEntry(i1, i2));
    
        // test to see if the pair is in the list
        if (items.Contains(MakeEntry(i1, i2)))
        {
            // do whatever
        }
    }
