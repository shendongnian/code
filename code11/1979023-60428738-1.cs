        var modelProperties = modelType.GetProperties();// modelType is your generic object type
        var instance = Activator.CreateInstance(modelType); 
        
    foreach (var property in modelProperties)
    {
      var propertyInfo = instance.GetType().GetProperty(property.Name);
      var propertyValue = yourList.FirstOrDefault(x=>x.Key==property.Name);
      propertyInfo.SetValue(instance, ChangeType(propertyValue, propertyInfo.PropertyType), null);       
    }
