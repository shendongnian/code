    private static void ReadPropertiesRecursive(Type type)
        {
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    var FamilyName = property.GetValue(property))// something like this
                    //do what u want with searched values
                }
                if (property.PropertyType.IsClass)
                {
                    ReadPropertiesRecursive(property.PropertyType);
                }
            }
        }
