            public void SetProperty(PropertyInfo property, string value)
        {
            //Get the type we need to cast to.
            Enum.TryParse(property.PropertyType.Name, true, out TypeCode enumValue); //Get the type based on typecode
            //Cast to that type
            var convertedValue = Convert.ChangeType(value, enumValue); //Convert the value to that of the typecode
            //Assign
            property.SetValue(this, convertedValue); // Set the converted value
