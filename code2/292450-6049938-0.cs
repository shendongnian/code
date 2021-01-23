    var list = new List<string> { "a", "b", "c" };
    for (int i = 0; i < list.Count; i++)
    {
        list[i]=list[i].ToUpper();
    }
    // list contains {"A", "B", "C"}
