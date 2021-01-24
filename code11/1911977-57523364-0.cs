    void InitializeViewModel(MyEntity entity)
            {
    
                Type objectType = entity.GetType();
                var properties =
                  entity.GetType().GetProperties().Where(p => p.PropertyType.IsClass
                   && !p.PropertyType.FullName.StartsWith("System."));
    
                foreach (PropertyInfo propertyInfo in properties)
                {
                    var instance = Activator.CreateInstance(propertyInfo.PropertyType);
                    objectType.GetProperty(propertyInfo.Name).SetValue(entity, instance);
                }
            }
