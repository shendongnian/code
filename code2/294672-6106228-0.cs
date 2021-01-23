    #region Encrypt
    public string Encrypt(string simpletext, string keys)
    {
        try
        {
            XCryptEngine xe = new XCryptEngine();
            xe.Algorithm = XCrypt.XCryptEngine.AlgorithmType.DES; //DES = Data Encryption Standard
            string cipher = xe.Encrypt(simpletext, keys);
            if (cipher != null)
                return (cipher);
            else
                return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region Decrypt
    public string Decrypt(string simpletext, string keys)
    {
        try
        {
            XCryptEngine xe = new XCryptEngine();
            xe.Algorithm = XCrypt.XCryptEngine.AlgorithmType.DES;
            //Console.WriteLine(xe.Decrypt(simpletext, keys));
            simpletext = simpletext.Replace(" ", "+");
            string cipertext = xe.Decrypt(simpletext, keys);
            if (cipertext != null)
                return (cipertext);
            else
                return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
