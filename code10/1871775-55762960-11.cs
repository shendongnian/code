    public static IEnumerable<MemberInfo> GetStringMembers<T>()
    {
        var result = new List<MemberInfo>();
        result.AddRange(
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(property => property.PropertyType == typeof(string)));
        result.AddRange(
            typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Where(field => field.FieldType == typeof(string)));
        return result;
    }
