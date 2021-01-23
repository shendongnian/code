    var myType = typeof(MyClass<>);
    var typeConstraints = myType.GetGenericArguments().First().GetGenericParameterConstraints();
    var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
    var genericTypes = allTypes.Where(t => typeConstraints.All(tc => tc.IsAssignableFrom(t))).Select(t => myType.MakeGenericType(t));
    foreach (var type in genericTypes)
    {
        ...
    }
