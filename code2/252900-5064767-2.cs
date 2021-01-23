    public IEnumerable<PropertyInfo> GetNonTranslatableProperties(WebControl control)
    {
        foreach (PropertyInfo property in control.GetType().GetProperties())
        {
            if(
            property
            .GetCustomAttributes(true)
            .Count(item => item is DoNotTranslateAttribute) > 0)
                yield return property;
        }        
    }
