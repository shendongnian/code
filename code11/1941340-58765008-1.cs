    public string GetDefaultBindingPropertyValue(Control c)
    {
        var att = c.GetType().GetCustomAttributes(true)
            .OfType<DefaultBindingProperty>().FirstOrDefault();
        return att?.Name;
    }
