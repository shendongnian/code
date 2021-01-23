    Properties.Settings.Default[string value] =
    
        foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties) 
        {    
        if (Double.TryParse(GenerateValue()), out result))  
           {        
    
    Properties.Settings.Default[ currentProperty.Name ] = result.ToString();
              Properties.Settings.Default.Save(); 
            } 
        } 
