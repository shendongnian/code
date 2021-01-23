    var person = new Person {Firstname = "John", Surname = "Smith", Age = 30};
    var model = ProtoBuf.Meta.TypeModel.Create();
    //add all properties you want to serialize. in this case we just loop over all the public properties of the class
    var properties = typeof (Person).GetProperties().Select(p => p.Name).ToArray();
    model.Add(typeof(Person), true).Add(properties);
    byte[] bytes;
    using (var memoryStream = new MemoryStream())
    {
        model.Serialize(memoryStream, person);
        bytes = memoryStream.GetBuffer();
    }
