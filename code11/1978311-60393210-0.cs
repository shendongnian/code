    public static string Serialize(object obj)
    {
        StringBuilder stringBuilder = new StringBuilder();
        IEnumerable<PropertyInfo> properties = obj.GetType().GetProperties().Where(p => p.GetIndexParameters().Length == 0);
        bool isArray = typeof(IEnumerable).IsAssignableFrom(obj.GetType()) ? true : false;
        if (isArray)
            stringBuilder.Append($"[");
        else
            stringBuilder.Append($"{{");
        if (!isArray)
            foreach (var property in properties)
                if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
                    stringBuilder.Append($"\"{property.Name}\": \"{property.GetValue(obj)}\", ");
                else
                    stringBuilder.Append($"\"{property.Name}\": {Serialize(property.GetValue(obj))}, ");
        else
            foreach (var i in obj as IEnumerable)
                stringBuilder.Append($"\"{i}\", ");
        string temp = stringBuilder.ToString().Trim().Remove(stringBuilder.ToString().Length - 2);
        stringBuilder.Clear();
        stringBuilder.Append(temp);
        if (isArray)
            stringBuilder.Append($"]");
        else
            stringBuilder.Append($"}}");
        return stringBuilder.ToString();
    }
