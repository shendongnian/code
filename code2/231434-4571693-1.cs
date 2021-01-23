    protected void RaiseChanged<TProperty>(Expression<Func<TProperty>> propertyExpresion)
    {
        var property = propertyExpresion.Body as MemberExpression;
        if (property == null || !(property.Member is PropertyInfo) ||
            !IsPropertyOfThis(property))
        {
            throw new ArgumentException(string.Format(
                CultureInfo.CurrentCulture,
                "Expression must be of the form 'this.PropertyName'. Invalid expression '{0}'.",
                propertyExpresion), "propertyBLOCKED EXPRESSION;
        }
    
        this.OnPropertyChanged(property.Member.Name);
    }
