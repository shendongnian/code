    IEnumerable<object[]> BuildCollectionByPropertyDependance(object[] objects)
    {
        return objects
            .GroupBy(o => CountNestedProperties(o.GetType()))
            .OrderBy(grp => grp.Key)
            .Select(grp => grp.ToArray());
    }
    int CountNestedProperties(Type type)
    {
        if (type.IsPrimitive)
        {
            return 1;
        }
        return 1 + type.GetProperties().Sum(prop => CountNestedProperties(prop.PropertyType));
    }
