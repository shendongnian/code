    var services = new ServiceCollection();
    services.AddDataProtection()
        .PersistKeysToSqlServer("INTRANET");// with custom datastore
    // .PersistKeysToFileSystem(new DirectoryInfo("c:\\temp\\secu"));
    
    var providerService = services.BuildServiceProvider();
    var providerProtection = providerService.GetDataProtectionProvider();
    
    var dataProtector = providerProtection.CreateProtector("INTRANET");
    //var ticketFormat = new AspNetTicketDataFormat(new DataProtectorShim(dataProtector));
    
    var plaintext = "mon texte";
    var protectText = dataProtector.Protect(plaintext);
    var unprotect = dataProtector.Unprotect(protectText);
    Debug.Assert(plaintext == unprotect);
