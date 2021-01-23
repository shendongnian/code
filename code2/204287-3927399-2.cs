    public void SetPropertyValues(IEnumerable<XElement> elements)
    {
        var propList = typeof(SessionProperties).GetProperties();
        foreach (var elm in elements)
        {
            var nm = elm.Element("name").Value;
            var val = elm.Element("value").Value;
                
            // MUST throw an exception if there are no matches...
            var pi = propList.First(c => c.GetCustomAttributes(true)
                       .OfType<DBSPropAttribute>()
                       .First()
                       .MappingField == nm);
            pi.SetValue(this, TypeConverterMap[pi.PropertyType](val), null);
        }
    }
