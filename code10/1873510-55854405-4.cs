    public void Apply(ActionModel action)
    {
        SeparatedQueryStringAttribute attribute = null;
        for (int i = 0; i < action.Parameters.Count; i++)
        {
            var parameter = action.Parameters[i];
            var commaSeparatedAttr = parameter.Attributes.OfType<CommaSeparatedAttribute>().FirstOrDefault();
            if (commaSeparatedAttr != null)
            {
                if (attribute == null)
                {
                    attribute = new SeparatedQueryStringAttribute(",", commaSeparatedAttr.RemoveDuplicatedValues);
                    parameter.Action.Filters.Add(attribute);
                }
                attribute.AddKey(parameter.ParameterName);
            }
            else
            {
                // here the trick to evaluate nested models
                var props = parameter.ParameterInfo.ParameterType.GetProperties();
                if (props.Length > 0)
                {
                    // start the recursive call
                    EvaluateProperties(parameter, attribute, props);
                }
            }
        }
     }
