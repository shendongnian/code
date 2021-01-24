    // Define the behavior and get the object list
    var objectList = new List<Something>();
    string propertyName = "SomeFlag";
    PropertyInfo pi = typeof(Something).GetProperty(propertyName);
    MethodInfo setter = pi.GetSetMethod();
    object value = true;
    // Call your processing method later on
    SetProperties(objectList, setter, value);
    void SetProperties<T>(List<T> objects, MethodInfo setter, object value)
    {
        var arguments = new object[] { value } ;
        objects.ForEach(o => setter.Invoke(o, arguments));
    }
