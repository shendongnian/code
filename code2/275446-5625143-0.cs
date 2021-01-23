    public TAttribute GetAttribute<TAttribute>(this ICustomAttributeProvider provider, bool inherit = false)
      where TAttribute : Attribute
    {
      return GetAttributes<TAttribute>(provider, inherit).FirstOrDefault();
    }
    public IEnumerable<TAttribute> GetAttributes<TAttribute>(this ICustomAttributeProvider provider, bool inherit = false)
      where TAttribute : Attribute
    {
      return provider.GetCustomAttributes(typeof(TAttribute), inherit).Cast<TAttribute>()
    }
