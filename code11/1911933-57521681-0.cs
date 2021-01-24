    List<ValueTuple<string, string, object>> toBeDeleted = new List...; //asuming kvp.Key and kvp2.Key are strings and the item is object, use your actuall types
    ....
    //instead of alertSortedByCompanyAndType[kvp.Key][kvp2.Key].Remove(item);
    toBeDeleted.Add((kvp.Key,kvp2.Key,item))
    ....
    //after the foreach nests
    foreach( var d  in toBeDeleted)
    alertSortedByCompanyAndType[d.Item1][d.Item2].Remove(d.Item3);
