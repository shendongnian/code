    private void SavePrivateKey(AsymmetricAlgorithm aa)
    {
        System.Console.Write("This is ");
        try
        {
            aa.ToXmlString(true);
        }
        catch(CryptographicException ce)
        {
            System.Console.Write("not ");
        }
        System.Console.WriteLine("a private key");
    }
