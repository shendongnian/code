    public static string GetFriendlyName(this Type type)
    {
        if (type.IsGenericType)
        {
            var name = type.Name.Substring(0, type.Name.IndexOf('`'));
            var types = string.Join(",", type.GetGenericArguments().Select(GetFriendlyName));
            return $"{name}<{types}>";
        }
        else
        {
            return type.Name;
        }
    }
