    private void Step()
    {
        var all = new List<IActable>();
        all.AddRange(aList);
        all.AddRange(bList);
        all.AddRange(cList);
        
        foreach (IActable a in all)
        {
            a.Act();
        }
    }
