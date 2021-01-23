    static GraphFactory()
    { 
        var items = (
            from type in _assembly.GetTypes()
            where type.GetInterface(typeof(IGraph).FullName) != null
            from attribute in type.GetCustomAttributes(true)
                .OfType<GraphTypeAttribute>
            select new { attribute, type }).ToArray();
        ValidateTypes(items);
        _item = items.ToDictionary(
            k => k.attribute.CustomType, e => e.type);
    }
    private static void ValidateTypes<T>(T[] items)
    {
        var firstDoubleCustomType = (
            from item in items
            group item by item.attribute.CustomType into g
            where g.Count() > 1
            select g.Key).FirstOrDefault();
        if (firstDoubleCustomType != null)
        {
            throw new InvalidProgramException(
               "Doube: " + firstDoubleCustomType.ToString());
        }
    }
