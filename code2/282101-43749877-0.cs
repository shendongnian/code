    public static class ObjectInitializationSerializer
    {
        private static string GetCSharpString(object o)
        {
            if (o is bool)
            {
                return $"{o.ToString().ToLower()}";
            }
            if (o is string)
            {
                return $"\"{o}\"";
            }
            if (o is int)
            {
                return $"{o}";
            }
            if (o is decimal)
            {
                return $"{o}m";
            }
            if (o is DateTime)
            {
                return $"DateTime.Parse(\"{o}\")";
            }
            if (o is Enum)
            {
                return $"{o.GetType().FullName}.{o}";
            }
            if (o is IEnumerable)
            {
                return $"new {GetClassName(o)} \r\n{{\r\n{GetItems((IEnumerable)o)}}}";
            }
            return CreateObject(o).ToString();
        }
        private static string GetItems(IEnumerable items)
        {
            return items.Cast<object>().Aggregate(string.Empty, (current, item) => current + $"{GetCSharpString(item)},\r\n");
        }
        private static StringBuilder CreateObject(object o)
        {
            var builder = new StringBuilder();
            builder.Append($"new {GetClassName(o)} \r\n{{\r\n");
            foreach (var property in o.GetType().GetProperties())
            {
                var value = property.GetValue(o);
                if (value != null)
                {
                    builder.Append($"{property.Name} = {GetCSharpString(value)},\r\n");
                }
            }
            builder.Append("}");
            return builder;
        }
        private static string GetClassName(object o)
        {
            var type = o.GetType();
            if (type.IsGenericType)
            {
                var arg = type.GetGenericArguments().First().Name;
                return type.Name.Replace("`1", $"<{arg}>");
            }
            return type.Name;
        }
        public static string Serialize(object o)
        {
            return $"var newObject = {CreateObject(o)};";
        }
    }
