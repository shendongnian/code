        ...
        //How to check for an array??? and add it to objProp dictionary
        if (property.PropertyType.IsArray)
        {
            //??? how to read all the elements of an array 
            objProp = GetProperties(property.PropertyType.GetElementType());
        }
        ...
