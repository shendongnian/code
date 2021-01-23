    // Group and filter
    var groups = items.GroupBy(i => new { i.Regn, i.DocName })
                      .Where(g => g.Count() > 1);
    // Iterate over each group with many items
    foreach (var g in groups) {
        var itemsInGroup = g.ToArray();
        // Iterate over the items and set DocName
        for (var i = 0; i < itemsInGroup.Length; ++i) {
            itemsInGroup[i].DocName = g.Key + "." + (i + 1).ToString();
        }
    }
