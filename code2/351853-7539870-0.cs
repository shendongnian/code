    static void AssignAllComplexTypeMembers(object instance, ComplexType value)
    {
         // If instance itself is null it has no members to which we can assign a value
         if (instance != null)
         {
            // Get all fields that are non-static in the instance provided...
            FieldInfo[] fields = instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        
            foreach (FieldInfo field in fields)
            {
               if (field.FieldType == typeof(ComplexType))
               {
                  // If field is of type ComplexType we assign the provided value to it.
                  field.SetValue(instance, value);
               }
               else if (field.FieldType.IsClass)
               {
                  // Otherwise, if the type of the field is a class recursively do this assignment 
                  // on the instance contained in that field. (If null this method will perform no action on it)
                  AssignAllComplexTypeMembers(field.GetValue(instance), value);
               }
            }
         }
      }
