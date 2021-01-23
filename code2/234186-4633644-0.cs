    public Employee(Person person)
    {
        // clone property values
        foreach (var property in person.GetType().GetProperties().Where(property => property.CanRead && property.CanWrite))
        {
            property.SetValue(this, property.GetValue(user, null), null);
        }
    }
