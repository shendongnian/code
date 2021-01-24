    public Mycontroller(IDataProtectionProvider provider)
    {
        this.myProtector = provider.CreateProtector("myPurpose");
    
        var encryptedString = this.myProtector.Protect("somestring");
    
    var decryptedstring = this.myProtector.Unprotect(encryptedString);
    
    }
