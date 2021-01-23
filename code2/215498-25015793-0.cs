    if (type.IsGenericInstance)
    {
        var genericInstance = (GenericInstanceType)type;
        var reflectionName = genericInstance.Namespace + "." + type.Name + "[" + string.Join(",",
            genericInstance.GenericArguments.Select(p => p.FullName).ToArray()) + "]";
        return Type.GetType(reflectionName, true);
    }
