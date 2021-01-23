    foreach (var p in model.GetType().GetProperties())
    {
       var valueOfDisplay = 
           p.GetCustomAttributesData()
            .Any(a => a.AttributeType.Name == "DisplayNameAttribute") ? 
                p.GetCustomAttribute<DisplayNameAttribute>().DisplayName : 
                p.Name;
    }
