    foreach(string propKey in temp.Properties.PropertyNames)
    {
        // Display each of the values for the property identified by
        // the property name.
        foreach (object property in temp.Properties[propKey])
        {
            Console.WriteLine("{0}:{1}", propKey, property.ToString());
        }
    }
