     foreach(var item in element)
     {
         foreach(var property in item.GetType().GetProperties())
         {
              // property.Name = Name of property.
              // property.GetValue(element, null) - Gets the value of the property (as System,Object).
         }
     }
