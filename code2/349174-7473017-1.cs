    var Contact = new Contact
    {
      Id = Guid.NewGuid(),
      Name = "Test",
      Address = null
    };
    var address = new Address
    {
          Id = Guid.NewGuid(),
          Postcode = "blah",
          // This is important
          Contact = Contact
    };
    contact.Address = address;
    DB.AddToContracts(Contract);
    DB.SaveChanges();
