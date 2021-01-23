    public static Field3270Attributes.Protection GetProtection(DependencyObject obj)
    {
        return (Field3270Attributes.Protection)obj.GetValue(ProtectionProperty);
    }
    public static void SetProtection(DependencyObject obj, Field3270Attributes.Protection value)
    {
        obj.SetValue(ProtectionProperty, value);
    }
