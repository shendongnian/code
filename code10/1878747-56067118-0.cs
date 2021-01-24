    public static IList GetRowValue(IEnumerable value, string propertyName)
    {
        // create an arraylist to be the result
        var result = new ArrayList();
        // loop in the objects
        foreach (var item in value)
        {
            // search for a property on the type of the object
            var property = item.GetType().GetProperty(propertyName);
            // if the property was found
            if (property != null)
            {
                // read the property value from the item
                var propertyValue = property.GetValue(item, null);
                // add on the result
                result.Add(propertyValue);
            }
        }
        return result;
    }
