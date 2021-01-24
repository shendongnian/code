    public static bool IsNullable(Type enclosingType, PropertyInfo property)
    {
        var nullable = property.CustomAttributes
            .Where(x => x.AttributeType.FullName == "System.Runtime.CompilerServices.NullableAttribute")
            .FirstOrDefault();
        if (nullable != null && nullable.ConstructorArguments.Count == 1)
        {
            var attributeArgument = nullable.ConstructorArguments[0];
            if (attributeArgument.ArgumentType == typeof(byte[]))
            {
                var args = (ReadOnlyCollection<CustomAttributeTypedArgument>)attributeArgument.Value;
                if (args.Count > 0 && args[0].ArgumentType == typeof(byte))
                {
                    return (byte)args[0].Value == 2;
                }
            }
            else if (attributeArgument.ArgumentType == typeof(byte))
            {
                return (byte)attributeArgument.Value == 2;
            }
        }
        var context = enclosingType.CustomAttributes
            .Where(x => x.AttributeType.FullName == "System.Runtime.CompilerServices.NullableContextAttribute")
            .FirstOrDefault();
        if (context != null &&
            context.ConstructorArguments.Count == 1 &&
            context.ConstructorArguments[0].ArgumentType == typeof(byte))
        {
            return (byte)context.ConstructorArguments[0].Value == 2;
        }
        // Couldn't find a suitable attribute
        return false;
    }
