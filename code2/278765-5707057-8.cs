    private void Step()
        {
            var all = new List<IActable>();
            all.AddRange(aList);
            all.AddRange(bList);
            all.AddRange(cList);
    
            all.AsParallel().ForAll(a=>a.Act());
        }
