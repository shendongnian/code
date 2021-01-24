    public static void SetStringValue<T>(IValidate data, string propertyName, 
        string valuePath, Func<string> value, bool required)
    {
        if(data == null)
            throw new ArgumentNullException(nameof(data));
 
        var property = data.GetType().GetProperty(propertyName);
        if(property == null)
            throw new ArgumentException($"In {data.GetType()} => SetStringValue.  " + 
                $"Passed property {propertyName}, but property doesn't exist.");
        
        var unwrapped = value();
        try
        {
            if (string.IsNullOrEmpty(unwrapped))
            {              
                if (required)
                    data.DataValidationErrors.Add($"{valuePath} can't be empty");
                
                unwrapped = null; // this might be unecessary.
            }
                   
            property.SetValue(data, unwrapped);
            
        }
        catch
        {
            //property doesn't exist
            if (required)
                data.DataValidationErrors.Add($"{valuePath} doesn't exist");
            
            // What is this supposed to acchieve?
            data.GetType().GetProperty(propertyName).SetValue(data, null);
            
            // This is poor exception handling.
        }
    }
