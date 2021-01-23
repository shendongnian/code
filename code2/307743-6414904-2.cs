    PropertyInfo[] properties = this.GetType().GetProperties();
    foreach (PropertyInfo property in properties)
    {
        if (property.PropertyType.IsAssignableFrom(typeof(IEnumerable<IAnimal>)))
        {
            // Found a property that is an IEnumerable<IAnimal>
        }							
    }
