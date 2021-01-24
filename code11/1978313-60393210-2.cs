    public static string Serialize(object obj)
    {
        StringBuilder stringBuilder = new StringBuilder();
        IEnumerable<PropertyInfo> properties = obj.GetType().GetProperties();
        if (!obj.GetType().IsPrimitive && obj.GetType() != typeof(string))
        {
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
                    if (i.GetType().IsPrimitive || i.GetType() == typeof(string))
                        stringBuilder.Append($"\"{i}\", ");
                    else
                        stringBuilder.Append($"{Serialize(i)}, ");
            stringBuilder.Remove(stringBuilder.ToString().Length - 2, 2);
            if (isArray)
                stringBuilder.Append($"]");
            else
                stringBuilder.Append($"}}");
        }
        else
            stringBuilder.Append(obj.ToString());
        return stringBuilder.ToString();
    }
