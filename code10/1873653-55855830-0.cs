    var result = items.AsEnumerable()
                      .GroupBy(item => item.Field<string>("Value"))
                      .Where(g => g.Count() > 1)
                      .SelectMany(g => g.Where(x => !x.Field<string>("ID").StartsWith("4")));
    foreach (var r in result) {
        r.Delete();
    }
