    var address = Builder<Address>
        .CreateNew()
        .Build();
    
    var person2 = Builder<Person>
        .CreateNew()
        .With(x => x.Address = address)
        .Build();
    
    Assert.That(person2.Name, Is.EqualTo("Name1"));
    Assert.That(person2.Address, Is.Not.Null);
    Assert.That(person2.Address.Street, Is.EqualTo("Street1"));
    Assert.That(person2.Address.Zipcode, Is.EqualTo("Zipcode1"));
