    foreach (var property in typeof(Order).GetProperties(BindingFlags.Public | BindingFlags.Instance).
           Where(c => ValidTypes.Contains(c.PropertyType)))
    {
        var value = property.GetValue(order, null);
        if (value != null)
        {
            var formattable = value as IFormattable;
            writer.WriteElementString(property.Name, 
            formattable == null ? value.ToString() : formattable.ToString(null, CultureInfo.InvariantCulture));
        }
    }
