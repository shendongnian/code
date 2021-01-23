    public AccessLevelAgentBase(XElement agentElement)
    {
        var type = this.GetType();
        var props = from prop in type.GetProperties()
                    let attrib = prop.GetCustomAttributes(typeof(XmlElementAttribute), true)
                                        .OfType<XmlElementAttribute>()
                                        .FirstOrDefault()
                    where attrib != null
                    let elementName = string.IsNullOrWhiteSpace(attrib.ElementName) 
                                                ? prop.Name 
                                                : attrib.ElementName
                    let value = agentElement.Element(elementName)
                    where value != null
                    select new
                    {
                        Property = prop,
                        Element = value,
                    };
        foreach (var item in props)
        {
            var propType = item.Property.PropertyType;
            if (propType == typeof(string))
                item.Property.SetValue(this, (string)item.Element, null);
            else if (propType == typeof(int))
                item.Property.SetValue(this, (int)item.Element, null);
            else 
                throw new NotSupportedException();
        }
    }
