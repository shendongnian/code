    public bool Method1(out string errorMessage)
    {
        return TryEncryptPassword("foo", out errorMessage);
    }
    public bool Method2(SecureString password, out string errorMessage)
    {
        return TryEncryptPassword(password, out errorMessage);
    }
    private bool TryEncryptPassword(string password, out string errorMessage)
    {
        // ...get some variables...
        string encryptedPassword = encrypter.EncryptPasswordAndDoStuff(
               password, publicKey, privateKey, out salt);
        // ...
    }
    private bool TryEncryptPassword(SecureString password, out string errorMessage)
    {
        // ...get some variables...
        string encryptedPassword = encrypter.EncryptPasswordAndDoStuff(
               password, publicKey, privateKey, out salt);
        // ...
    }
