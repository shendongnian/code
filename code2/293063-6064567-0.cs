    Type typeB = b.GetType();
    foreach (PropertyInfo property in a.GetType().GetProperties())
    {
        if (!property.CanRead || (property.GetIndexParameters().Length > 0))
            continue;
        PropertyInfo other = typeB.GetProperty(property.Name);
        if ((other != null) && (other.CanWrite))
            other.SetValue(b, property.GetValue(a, null), null);
    }
