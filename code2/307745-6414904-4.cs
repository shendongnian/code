    PropertyInfo[] properties = this.GetType().GetProperties();
    foreach (PropertyInfo property in properties)
    {
        if (typeof(IEnumerable<IAnimal>).IsAssignableFrom(property.PropertyType))
        {
            // Found a property that is an IEnumerable<IAnimal>
        }							
    }
