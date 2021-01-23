    var idLookup = new Dictionary<int, Item>();
    var roots = new List<Item>();
    foreach([row]) {
        Item newRow = [read basic row];
        int? parentId = [read parentid]
        Item parent;
        if(parentId != null && idLookup.TryGetValue(parentId.Value, out parent)) {
            parent.Items.Add(newRow);
        } else {
            roots.Add(newRow);
        }
        idLookup.Add(newRow.Id, newRow);
    }
