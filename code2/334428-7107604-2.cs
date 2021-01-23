    var l1 = new Data1List();
    var l2 = new Data2List();
    foreach (var items in l1.GroupBy(d => d.JoinDate))
    {
        var d2 = new Data2 { JoinDate = items.Key };
        foreach (var item in items)
            d2.Sal.Add(item.Sal);
        l2.Add(d2);
    }
