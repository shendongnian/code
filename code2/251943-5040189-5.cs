        //Check if IsCustomPropertyAttribute is defined for this property or not
        bool isCustomAttributeDefined = Attribute.IsDefined(type.GetProperty
              (propertyDescriptor.Name), typeof(IsCustomPropertyAttribute));
        
        if (isCustomAttributeDefined == true)
           {
              //IsCustomPropertyAttribute is defined so get the attribute
              IsCustomPropertyAttribute myAttribute = 
                Attribute.GetCustomAttribute(type.GetProperty(propertyDescriptor.Name),
                typeof(IsCustomPropertyAttribute)) as IsCustomPropertyAttribute;
        
               //Check if current property is Custom Property or not
               if (myAttribute != null && myAttribute.IsCustomProperty == true)
                   {
                       AddProperty(propertyDescriptor);
                   }
            }
