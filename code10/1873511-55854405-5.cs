    private void EvaluateProperties(ParameterModel parameter, SeparatedQueryStringAttribute attribute, PropertyInfo[] properties)
    {
        for (int i = 0; i < properties.Length; i++)
        {
            var prop = properties[i];
            var commaSeparatedAttr = prop.GetCustomAttributes(true).OfType<CommaSeparatedAttribute>().FirstOrDefault();
            if (commaSeparatedAttr != null)
            {
                if (attribute == null)
                {
                    attribute = new SeparatedQueryStringAttribute(",", commaSeparatedAttr.RemoveDuplicatedValues);
                    parameter.Action.Filters.Add(attribute);
                }
                // get the binding attribute that implements the model name provider
                var nameProvider = prop.GetCustomAttributes(true).OfType<IModelNameProvider>().FirstOrDefault(a => !IsNullOrWhiteSpace(a.Name));
                attribute.AddKey(nameProvider?.Name ?? prop.Name);
            }
            else
            {
                // nested properties
                var props = prop.PropertyType.GetProperties();
                if (props.Length > 0)
                {
                   EvaluateProperties(parameter, attribute, props);
                }
            }
        }
    }
