    var query = from item in source
                group item by new { item.VendorCode, item.GroupType } into g
                select new { g.Key.VendorCode,
                             g.Key.GroupType,
                             Variance = ComputeVariance(g) };
    ...
    string ComputeVariance(IEnumerable<YourItemType> group)
    {
        var distinctVariance = group.Select(x => x.Variance)
                                    .Distinct();
        using (var iterator = distinctVariance.GetEnumerator())
        {
            iterator.MoveNext(); // Assume this will return true...
            var first = iterator.Current;
            return iterator.MoveNext() ? "custom" : first.ToString();
        }
    }
