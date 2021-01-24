    PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            // Add this or else u might run into problems later
            if (!property.CanWrite)
            {
                continue;
            }
            // Hide flags is an Enumeration. the default value for it is HideFlags.None 
            // i assume u dont chnage this value, so for your use case this will be Ok
            if (property.PropertyType.IsEnum && property.ToString() == "UnityEngine.HideFlags hideFlags")
            {
                property.SetValue(my_Component, HideFlags.None);
                continue;
            }
            property.SetValue(my_Component, property.GetValue(original));
        }
