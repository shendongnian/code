    private static FrameworkElement CreateContent(System.Reflection.PropertyInfo propertyInfo, object parent)
    {
        object propValue = propertyInfo.GetValue(parent, null);
        if (propValue is ICollection)
            return new TextBlock() { Text = ((ICollection)propValue).Count.ToString() };
        else if (propValue is ...)
            return new TextBlock() { Text = ... };
        else
            return new TextBlock() { Text = propValue.ToString() };
    }
