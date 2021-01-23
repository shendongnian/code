    public InheritModel Merge(InheritModel current, InheritModel orig)
    {
        var result = new InheritModel();
        var properties = TypeDescriptor.GetProperties(typeof(InheritModel));
        foreach (PropertyDescriptor property in properties)
        {
            var currentValue = property.GetValue(current);
            if (currentValue != property.GetValue(orig))
            {
                property.SetValue(result, currentValue);
            }
        }
        return result;
    }
