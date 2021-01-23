    var property = type.GetProperty("aux", BindingFlags.Instance | BindingFlags.NonPublic);
    if (property.IsDefined(typeof(My1Attribute))) 
    {
        // Property has the attribute.
    }
