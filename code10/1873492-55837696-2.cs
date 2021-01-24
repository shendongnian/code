    public static void SetStringValue(IValidate data, string propertyName, 
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
        catch(Exception e)
        {
            // This is probably a bad idea.
            property.SetValue(data, null);
           if (required)
               data.DataValidationErrors.Add(Atleast put a better message here. e.Message ...);
        }
    }
