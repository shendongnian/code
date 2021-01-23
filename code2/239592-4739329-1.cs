        // Contact is statically typed.
        Contact c = new Contact();
        c.FirstName = "test";       
        // Treat as dynamic and attach some extra properties:
        dynamic dynContact = c;
        dynContact.AddressOne = "Somewhere";
        dynContact.AddressTwo = "Someplace else";
        Console.WriteLine(dynContact.AddressOne); 
        Console.WriteLine(dynContact.AddressTwo); 
