    private static bool RequiredAttrExists(ModelMetadata metaData)
    {
        if(!metaData.ModelType.IsValueType && metaData.IsRequired)
            return true;
        else if (metaData.ModelType.IsValueType && metaData.ContainerType.GetProperty(metaData.PropertyName).GetCustomAttributes(typeof(RequiredAttribute), false).Any())
            return true;
        return false;
    }
