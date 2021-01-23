    public string GetTableName<T>(DbContext context)
                where T: class
    {
        var entitySet= GetEntitySet<T>(context);
        if (entitySet == null)
            throw new Exception("Unable to find entity set '{0}' in edm metadata".F(typeof(T).Name));
        var tableName = GetStringProperty(entitySet, "Schema") + "." + GetStringProperty(entitySet, "Table");
        return tableName;
    }
    private string GetStringProperty(MetadataItem entitySet, string propertyName)
    {
        MetadataProperty property;
        if (entitySet == null)
            throw new ArgumentNullException("entitySet");
        if (entitySet.MetadataProperties.TryGetValue(propertyName, false, out property))
        {
            string str = null;
            if (((property != null) &&
                (property.Value != null)) &&
                (((str = property.Value as string) != null) &&
                !string.IsNullOrEmpty(str)))
            {
                return str;
            }
        }
        return string.Empty;
    }
