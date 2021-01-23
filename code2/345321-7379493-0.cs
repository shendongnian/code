    var ints = new List<int>();
    ints.AddRange(Enumerable.Range(1, 10));
    int y = 11;
    var moreInts = new List<int>();
    foreach(int x in ints.AsReadOnly())
    {
        moreInts.Add(y++);
        Console.WriteLine(x);
    }
    ints.AddRange(moreInts);
