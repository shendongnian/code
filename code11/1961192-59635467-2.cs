    private static string PrintObject(object obj, int depth = 1)
    {
        var type = obj.GetType();
        if (type.IsPrimitive || type == typeof(Decimal) || type == typeof(String))
            return "\"" + obj.ToString() + "\"";
        var props = type.GetProperties();
        string ret = "";
        for (var i = 0; i < props.Length; i++)
        {
            var val = props[i].GetValue(obj);
            ret += new string('\t', depth) + "\"" + props[i].Name + "\":" + PrintObject(val, depth + 1);
            if (i != props.Length - 1)
                ret += "," + Environment.NewLine;
        }
    
        return ("{" + Environment.NewLine + ret + Environment.NewLine + new string('\t', depth - 1) + "}").Replace("\t", "  ");
    }
