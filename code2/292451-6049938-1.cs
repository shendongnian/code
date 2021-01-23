    var list = new List<string> { "a", "b", "c" };
    int count=list.Count;
    for (int i = 0; i < count; i++)
    {
        list[i]=list[i].ToUpper();
    }
    // list contains {"a", "b", "c", "A", "B", "C"}
