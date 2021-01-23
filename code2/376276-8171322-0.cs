    const string given = "aaa XXX,bbb XXX,ccc XXX,aaa XXX";
    var givenSplit = new List<string>(given.Split(','));
    foreach(var item in givenSplit.Where(g => g.IndexOf("aAa", StringComparison.InvariantCultureIgnoreCase) > -1))
    {
        Console.WriteLine(item); 
    }
    // two items are written
