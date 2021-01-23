    private void Step()
    {
        var all = new List<IActable>();
        all.AddRange(aList);
        all.AddRange(bList);
        all.AddRange(cList);
        all = all.Shuffle(new Random());
        
        foreach (IActable a in all)
        {
            a.Act();
        }
    }
