    AdventureWorksDataContext db = new AdventureWorksDataContext();
    
    // LINQ query to get StateProvince
    StateProvince state = (from states in db.StateProvinces
                           where states.CountryRegionCode == "AU" && states.StateProvinceCode == "NSW"
                           select states).FirstOrDefault();
    // LINQ function to get AddressType
    AddressType addrType = db.AddressTypes.FirstOrDefault(s => s.Name == "Home");
    
    Customer newCustomer = new Customer()
    {
        ModifiedDate= DateTime.Now,
        AccountNumber= "AW12354", 
        CustomerType='I',
        rowguid= Guid.NewGuid(),
        TerritoryID= state.TerritoryID    // Relate record by Keys
    };
    Contact newContact = new Contact()
    {
        Title = "Mr",
        FirstName = "New",
        LastName = "Contact",
        EmailAddress = "newContact@company.com",
        Phone = "(12) 3456789", 
        PasswordHash= "xxx",
        PasswordSalt= "xxx",
        rowguid = Guid.NewGuid(),
        ModifiedDate = DateTime.Now
    };
    Individual newInd = new Individual()
    {
        Contact= newContact,    // Relate records by objects (we dont actually know the Keys for the new records yet)
        Customer= newCustomer,
        ModifiedDate= DateTime.Now
    };
    Address newAddress = new Address()
    {
        AddressLine1= "12 First St",
        City= "Sydney",
        PostalCode= "2000", 
        ModifiedDate=DateTime.Now,
        StateProvince= state,
        rowguid = Guid.NewGuid()
    };
    
    // Link our customer with their address via a new CustomerAddress record
    newCustomer.CustomerAddresses.Add(new CustomerAddress() { Address = newAddress, Customer = newCustomer, AddressType = addrType, ModifiedDate = DateTime.Now, rowguid = Guid.NewGuid() });
    
    // Save changes to the database
    db.SubmitChanges();
    
