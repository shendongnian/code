    List<T1> t1 = t2.GroupBy(g => new
    {
        g.property1,
        g.property2
    }).Select(groupedItems =>
        {
            // My code starts here
            bool? result = null;
            var bools = groupedItems
                .OrderBy(z => z.BoolProperty)
                .TagFirstLast((z, first, last) => new { z, firstOrLast = first || last })
                .Where(z => z.firstOrLast)
                .Select(z => z.z.BoolProperty).ToList();
    
            if (bools.Count == 0)
            {
                // Do nothing
            }
            else if (bools.First() == bools.Last())
            {
                result = bools.First();
            }
            // My code ends here
    
            return new T1
            {
                property1 = groupedItems.Key.property1,
                property2 = groupedItems.Key.property2,
                BoolProperty = result
            };
        }).ToList();
