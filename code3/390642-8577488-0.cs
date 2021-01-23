    public void SomeMethod<T>(T object, string propName) 
        where T : INotifyPropertyChanging, INotifyPropertyChanged
    (
        var type = typeof(T);
        var property = type.GetProperty(propName);
        if(property == null)
            throw new ArgumentException("Property doesn't exist", "propName");
        var value = property.GetValue(object, null);
    )
