    static CodeTypeReference CreateTypeReference(Type type)
    {
        var typeName = (type.IsPrimitive || type == typeof(string)) ? type.FullName : type.Name;
        var reference = new CodeTypeReference(typeName);
        if (type.IsArray)
        {
            reference.ArrayElementType = CreateTypeReference(type.GetElementType());
            reference.ArrayRank = type.GetArrayRank();
        }
        if (type.IsGenericType)
        {
            foreach (var argument in type.GetGenericArguments())
            {
                reference.TypeArguments.Add(CreateTypeReference(argument));
            }
        }
        return reference;
    }
