    var genCollType = value.GetType()
                           .GetInterfaces()
                           .FirstOrDefault
                               (i => i.IsGenericType 
                                  && i.GetGenericTypeDefinition() == typeof(ICollection<>));
    
    if (genCollType != null)
    {
        int count = (int)genCollType.GetProperty("Count")
                                    .GetValue(value, null);
        return CreateResult(validationContext, count);   
    }
        
                             
