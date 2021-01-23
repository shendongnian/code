    var attribute = typeof(TransformationItem)
        .GetAttributes<XmlArrayItemAttribute>(true)
        .Where(attr => !string.IsNullOrEmpty(attr.ElementName))
        .FirstOrDefault();
    if (attribute != null)
    {
        string elementName = attribute.ElementName;
        // Do stuff...
    }    
