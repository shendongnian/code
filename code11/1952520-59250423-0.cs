    var l1 = new List<List1>();
    var l2 = new List<List2>();
    var listInfos = new List<ListInfo>();
    l2.ForEach(i => listInfos.AddRange(i.ListInfo));
    var x =  l1.Select(i => listInfos.Any(info=>info.StudentCode == i.StudentCode));
