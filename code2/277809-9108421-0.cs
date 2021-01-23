    var _keypair = new ECKeyPairGenerator("EC").Init(
        new KeyGenerationParameters(_SecureRandomSingleton, 256)).GenerateKeyPair();
    // For the love of all that's holy don't do this in production, encrypt your keys!
    var pkcs8gen = new Pkcs8Generator(_keypair.Private);
    Stream pkcs8stream = new MemoryStream();
    using(System.IO.TextWriter pkcs8writer = new StreamWriter(pkcs8stream))
    {
        var mywriter = new Org.BouncyCastle.OpenSsl.PemWriter(pkcs8writer);
        mywriter.WriteObject(pkcs8gen.Generate());
        mywriter.Writer.Flush();
    }
