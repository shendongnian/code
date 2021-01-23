    foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
    {
        if (propertyInfo.PropertyType.IsArray)
        {
            // first get the array
            object[] array = (object[])propertyInfo.GetValue(data)
            // then find the length
            int arrayLength = array.GetLength(0);
            // now check if the length is > 0
    
        }
    }
