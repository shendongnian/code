    private static string PrettyName(Type type)
    {
        if (type.GetGenericArguments().Length == 0)
        {
            return type.Name;
        }
        var genericArguments = type.GetGenericArguments();
        var typeDefeninition = type.Name;
        var unmangledName = typeDefeninition.Substring(0, typeDefeninition.IndexOf("`"));
        return unmangledName + "<" + String.Join(",", genericArguments.Select(PrettyName)) + ">";
    }
