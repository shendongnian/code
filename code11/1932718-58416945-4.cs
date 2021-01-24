    private void validate(PipelineStageRequiredField field, Guid PipelineID, object model, List<string> required, List<string> errors) {
        if (model != null) {
            var propertyName = field.RefelectionProperty;
            var objectType = model.GetType();
            var propertyInfo = getProperty(objectType, propertyName);
            if (propertyInfo != null) {
                var isValidModel = buildRequiredFieldCheckDelegate(objectType, propertyInfo);
                if (!(bool)isValidModel.DynamicInvoke(model)) {
                    required.Add(propertyInfo.Name);
                }
            } else {
                errors.Add("The " + field.RefelectionClass + " does not have a Property of " + propertyName);
            }
        } else {
            errors.Add("Error: Could not find a " + field.RefelectionClass + " with this Pipeline: '" + PipelineID.ToString() + "'");
        }
    }
    private static PropertyInfo getProperty(Type type, string propertyName) {
        return type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
    }
    
