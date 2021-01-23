    public static string Warning(this Object object) 
    {
        System.Attribute[] attrs = System.Attribute.GetCustomAttributes(object);
    
        foreach (System.Attribute attr in attrs)
            {
                if (attr is WarningAttrbiute)
                {
                    return (WarningAttribute)attr.Warning;
                }
            } 
    }
