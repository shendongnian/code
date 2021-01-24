    var fields = properties
        .Select(property => typeBuilder.DefineField(
            property.Name,
            ((PropertyInfo)property).PropertyType,
            FieldAttributes.Public
        )).Cast<FieldInfo>()
        .ToArray();
    GenerateConstructor(typeBuilder, fields); // <--
    GenerateEquals(typeBuilder, fields);
    GenerateGetHashCode(typeBuilder, fields);
    return typeBuilder.CreateType();
