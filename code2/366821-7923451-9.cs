    var person = new Person {Firstname = "John", Surname = "Smith", Age = 30};
    var model = ProtoBuf.Meta.TypeModel.Create();
    //add all properties you want to serialize. 
    //in this case we just loop over all the public properties of the class
    //Order by name so the properties are in a predictable order
    var properties = typeof (Person).GetProperties().Select(p => p.Name).OrderBy(name => name).ToArray();
    model.Add(typeof(Person), true).Add(properties);
    byte[] bytes;
    using (var memoryStream = new MemoryStream())
    {
        model.Serialize(memoryStream, person);
        bytes = memoryStream.GetBuffer();
    }
