    static IEnumerable<Type> GetMissingTypes(IEnumerable<Type> types, List<object> objects)
    {
        List<Type> existingTypes = objects.ConvertAll(delegate(object obj) { return obj.GetType(); });
        foreach (Type type in types)
        {
            if (!existingTypes.Contains(type))
                yield return type;
        }
    }
    // ...
    List<Type> types = new List<Type>() { typeof(int), typeof(double), typeof(float) };
    List<object> objects = new List<object>() { 1, 2, 3, 2d, 4d };
    IEnumerable<Type> missingTypes = GetMissingTypes(types, objects);
