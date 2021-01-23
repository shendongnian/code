    using System.Reflection;
    .
    .
    .
    /// <summary> copy base class instance's property values to this object. </summary>
    private void InitInhertedProperties (object baseClassInstance)
    {
        foreach (PropertyInfo propertyInfo in baseClassInstance.GetType().GetProperties())
        {
            object value = propertyInfo.GetValue(baseClassInstance, null);
            if (null != value) propertyInfo.SetValue(this, value, null);
        }
    }
 
