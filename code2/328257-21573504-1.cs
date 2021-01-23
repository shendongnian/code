    protected string QualifyFieldId(ModelMetadata metadata, string fieldId, ViewContext viewContext)
    {
        // build the ID of the property
        string depProp = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(fieldId);
	
        var thisField = metadata.PropertyName + "_";
        if (depProp.StartsWith(thisField))
        // strip it off again
        depProp = depProp.Substring(thisField.Length);
	else if (null != metadata.ContainerType && !string.IsNullOrEmpty(metadata.ContainerType.Name))
        {
            depProp = metadata.ContainerType.Name + "_" + fieldId;
        }
        return depProp;
    }
