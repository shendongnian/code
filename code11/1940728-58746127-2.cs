    var lists = new List<List<int>>();
    lists.Add(new List<int> {1, 2, 3, 4, 5, 6 });
    lists.Add(new List<int> {1, 2, 3 });
    lists.Add(new List<int> {1, 2 });
    
    foreach (var list in listSources)
        lists.Add(list);
    var commons = GetCommonItems(lists);
