    var key = new RSACryptoServiceProvider(2048);
    string publicKey = key.ToXmlString(false);
    string privateKey = key.ToXmlString(true);
    Console.WriteLine(publicKey);
    Console.WriteLine(privateKey);
