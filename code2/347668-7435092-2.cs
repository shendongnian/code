    var modified = list1.Concat(list2)
                        .GroupBy(item => item.Id)
                        .Where(g => g.Select(item => item.ModificationDate)
                                     .Distinct().Count() != 1);
    // To propagate the modifications:
    foreach(var grp in modified) {
        var items = grp.OrderBy(item => item.ModificationDate);
        var target = items.First(); // earliest modification date = old
        var source = grp.Last();    // latest modification date = new
        // And now copy properties from source to target
    }
