    void SetProperties(object source, object target)
    {
        var customerType = target.GetType();
        foreach (var prop in source.GetType().GetProperties())
        {
            var propGetter = prop.GetGetMethod();
            var propSetter = customerType.GetProperty(prop.Name).GetSetMethod();
            var valueToSet = propGetter.Invoke(source, null);
            propSetter.Invoke(target, new[] { valueToSet });
        }
    }
