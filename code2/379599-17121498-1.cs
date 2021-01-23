    /// <summary>
    ///   Gets the index attributes on the specified property and the same property on any associated metadata type.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>IEnumerable{IndexAttribute}.</returns>
    IEnumerable<IndexAttribute> GetIndexAttributes(PropertyInfo property)
        {
        Type entityType = property.DeclaringType;
        var indexAttributes = (IndexAttribute[])property.GetCustomAttributes(typeof(IndexAttribute), false);
        var metadataAttribute =
            entityType.GetCustomAttribute(typeof(MetadataTypeAttribute)) as MetadataTypeAttribute;
        if (metadataAttribute == null)
            return indexAttributes; // No metadata type
        Type associatedMetadataType = metadataAttribute.MetadataClassType;
        PropertyInfo associatedProperty = associatedMetadataType.GetProperty(property.Name);
        if (associatedProperty == null)
            return indexAttributes; // No metadata on the property
        var associatedIndexAttributes =
            (IndexAttribute[])associatedProperty.GetCustomAttributes(typeof(IndexAttribute), false);
        return indexAttributes.Union(associatedIndexAttributes);
        }
