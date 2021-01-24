    static IEnumerable<IEnumerable<int>> List_2()
    {
        List<List<int>> parent = new List<List<int>>();
        List<int> list = new List<int> { 1, 2, 3, 3, 4, 5 };
        parent.Add(list);
        return parent; // no error, this works
    }
