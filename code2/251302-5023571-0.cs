    private object GetDefaultValue(SettingsProperty setting)
      {
             if (setting.PropertyType.IsEnum)
                 return Enum.Parse(setting.PropertyType, setting.DefaultValue.ToString());
    
            // Return the default value if it is set
            // Return the default value if it is set
             if (setting.DefaultValue != null)
             {
                 System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(setting.PropertyType);
                 return tc.ConvertFromString(setting.DefaultValue.ToString());
             }
             else // If there is no default value return the default object
             {
                 return Activator.CreateInstance(setting.PropertyType);
             }
       }
