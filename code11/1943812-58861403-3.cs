    IEnumerable<object[]> BuildCollectionByPropertyDependance(object[] objects)
    {
        return objects
            .GroupBy(o => o.GetType().GetProperties().Count)
            .OrderBy(grp => grp.Key)
            .Select(grp => grp.ToArray());
    }
