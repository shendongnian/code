    public void DoSomething(IEnumerable<string> list)
    {
        var repeatable = list.ToRepeatableEnumeration();
        if (repeatable.Any()) // <- no warning here anymore.
          // Further, this will read at most one item from list.  A
          // query (SQL LINQ) with a 10,000 items, returning one item per second
          // will pass this block in 1 second, unlike the ToList() solution / hack.
        {
            // ...
        }
        foreach (var item in repeatable) // <- and no warning here anymore, either.
          // Further, this will read in lazy fashion.  In the 10,000 item, one 
          // per second, query scenario, this loop will process the first item immediately
          // (because it was read already for Any() above), and then proceed to
          // process one item every second.
        {
            // ...
        }
    }
