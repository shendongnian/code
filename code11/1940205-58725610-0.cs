    var result = list
        .Aggregate(
            (IEnumerable<SubItem>)Array.Empty<SubItem>(), 
            (result, item) => 
                result.LastOrDefault()?.Status == item.Status
                    ? result.SkipLast(1).Concat(new [] { new SubItem { Status = item.Status, Value = result.Last().Value + item.Value } })
                    : result.Concat(new [] { item })
        )
        .ToList();
