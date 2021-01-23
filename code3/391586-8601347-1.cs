    var propNameTuples = from property in typeof(Test).GetProperties()
                         let nameAttribute = (NameAttribute)property.GetCustomAttributes
                                    (typeof(NameAttribute), false).SingleOrDefault()
                         where nameAttribute != null
                         select new { Property = property, nameAttribute.Name };
    foreach (var propNameTuple in propNameTuples)
    {
        Console.WriteLine("Property: {0} Name: {1}",
                          propNameTuple.Property.Name, propNameTuple.Name);
    }
