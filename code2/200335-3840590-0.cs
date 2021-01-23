        public static void Main()
    {
        var attribute = GetAttribute(typeof (MyWebControl), "StyleString", false);
        Debug.Assert(attribute != null);
        attribute = GetAttribute(typeof(SmarterWebControl), "StyleString", false);
        Debug.Assert(attribute == null);
        attribute = GetAttribute(typeof(SmarterWebControl), "StyleString", true);
        Debug.Assert(attribute == null);
    }
    private static ExternallyVisibleAttribute GetAttribute(Type type, string propertyName, bool inherit)
    {
        PropertyInfo property = type.GetProperties().Where(p=>p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        var list = property.GetCustomAttributes(typeof(ExternallyVisibleAttribute), inherit).Select(o => (ExternallyVisibleAttribute)o);
        return list.FirstOrDefault();
    }
