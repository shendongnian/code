    main()
    {
        Contact Contact = new Contact();
        If (Contact.Country == "DK")
        {
            var address = new AddressDK();
            address = "MyStreat";
            Contract.Address = address;
        }
        else
        {
            var address = new AddressInternational();
            address = "First line in foreign address";
            Contact.Address = address;
        }
    }
