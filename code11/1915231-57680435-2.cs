    public override void SetValue(TStructuralType instance, object value)
    {
        if (instance == null)
        {
            throw Error.ArgumentNull("instance");
        }
    
        if (_isCollection)
        {
            DeserializationHelpers.SetCollectionProperty(instance, _property.Name, edmPropertyType: null,
                value: value, clearCollection: true);
        }
        else
        {
            _setter(instance, value);
        }
    }
