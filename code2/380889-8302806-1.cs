    private void Assign(object objInstance, Expression<Func<T>> propertyExpression, object value)
    {
        string propertyNameToAssign = GetPropertyName(propertyExpression);
        //TODO use reflection to assign "value" to the property "propertyNameToAssign" of "objInstance"
    }
