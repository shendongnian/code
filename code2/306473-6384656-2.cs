    public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this ICustomAttributeProvider provider, bool inherit = false)
        where TAttribute : Attribute
    {
        return provider
            .GetCustomAttributes(typeof(TAttribute), inherit)
            .Cast<TAttribute>();
    }
