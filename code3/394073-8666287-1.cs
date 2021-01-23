    var property = vm.Product.GetType().GetProperty(field);
    // Convert.ChangeType does not work with nullable types, so we need
    // to get the underlying type.
    var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
    object convertedValue = Convert.ChangeType(val, type);
    property.SetValue(vm.Product, convertedValue, null);
