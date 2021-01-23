    Delegate getter = Delegate.CreateDelegate(
        typeof(Func<>).MakeGenericType(property.PropertyType), this,
        property.GetGetMethod(true));
    Delegate setter = Delegate.CreateDelegate(
        typeof(Action<>).MakeGenericType(property.PropertyType), this,
        property.GetSetMethod(true));
