    public static string TypeName(Type t) {
        if (!t.IsGenericType) return t.Name;
        StringBuilder ret = new StringBuilder();
        ret.Append(t.Name).Append("<");
        bool first = true;
        foreach(var arg in t.GetGenericArguments()) {
            if (!first) {
                ret.Append(", ");
                first = false;
            }
            ret.Append(TypeName(arg));
        }
        ret.Append(">");
        return ret.ToString();
    }
