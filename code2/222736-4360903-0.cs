    private static void SetEncryptedCookie(string name, string value)
    {
        var encryptName = SomeEncryptionMethod(name);
        Response.Cookies[encryptName].Value = SomeEncryptionMethod(value);
        //set other cookie properties here, expiry &c.
        //Response.Cookies[encryptName].Expires = ...
    }
    
    private static string GetEncryptedCookie(string name)
    {
        //you'll want some checks/exception handling around this
        return SomeDecryptionMethod(
                   Response.Cookies[SomeDecryptionMethod(name)].Value);
    }
