    public static string GetNameWithoutGenericArity(this Type t)
    {
        string name = t.Name;
        int index = name.IndexOf('`');
        return index == -1 ? name : name.Substring(name, index);
    }
