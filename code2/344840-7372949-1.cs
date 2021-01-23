    Contact Contact = new Contact();
    if (Contact.Country == "DK")
    {
        Contact.Address = new AddressDK();
        Contact.Address.Street = "MyStreat"
    }
    else
    {
        Contact.Address = new AddressInternational();
        Contact.Address.Address1 = "First line in foreign address"
    }
