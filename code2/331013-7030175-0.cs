    private static TripleDESCryptoServiceProvider GetCryptoProvider()
    {
        TripleDESCryptoServiceProvider cryptic = new TripleDESCryptoServiceProvider();
        try
        {
            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(CrypKey);
            Rfc2898DeriveBytes db = new Rfc2898DeriveBytes("sdddsdsd", 8);
            cryptic.IV = db.GetBytes(8);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            cryptic.Dispose(); // <------- Don't do this until you are done decrypting.
        }
        return cryptic;
    }
