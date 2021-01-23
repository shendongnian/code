    //...
        Type type = typeof(IList<string>);
        string definition = GetGenericTypeDefinitionString(type);
        //definition is "System.Collections.Generic.IList<System.String>"
    }
    static string GetGenericTypeDefinitionString(Type genericType) {
        string genericTypeDefName = genericType.GetGenericTypeDefinition().FullName;
        string typePart = genericTypeDefName.Substring(0, genericTypeDefName.IndexOf('`'));
        string argumentsPart = string.Join(",",
            Array.ConvertAll(genericType.GetGenericArguments(), (t) => t.FullName));
        return string.Concat(typePart, '<', argumentsPart, '>');
    }
