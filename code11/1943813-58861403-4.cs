    IEnumerable<object[]> BuildCollectionByPropertyDependance(object[] objects)
    {
        return objects
            .GroupBy(o => CountNestedProperties(o.GetType()))
            .OrderBy(grp => grp.Key)
            .Select(grp => grp.ToArray());
    }
    int CountNestedProperties(Type type, IList<Type> checked = null)
    {
        checked = checked ?? new List<Type>();
        if (checked.Contains(type))
        {
           return 0;
        }
        
        if (type.IsPrimitive)
        {
            return 1;
        }
        checked.Add(type);
        return 1 + type.GetProperties().Sum(prop => CountNestedProperties(prop.PropertyType, checked));
    }
