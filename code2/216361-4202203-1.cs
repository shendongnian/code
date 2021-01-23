    private readonly Dictionary<Tuple<string, string>, int> Table = 
        new Dictionary<Tuple<string, string>, int>
    {
        { Tuple.Create("A1", "A"), 1 },
        { Tuple.Create("A1", "B"), 2 },
        { Tuple.Create("A1", "C"), 3 },
        { Tuple.Create("B1", "A"), 4 },
        { Tuple.Create("B1", "B"), 5 },
        { Tuple.Create("B1", "C"), 6 },
        { Tuple.Create("C1", "A"), 7 },
        { Tuple.Create("C1", "B"), 8 },
        { Tuple.Create("C1", "C"), 9 },
    };
    public int this[string row, string column]
    {
        get
        {
            return Table[Tuple.Create(row, column)];
        }
    }
