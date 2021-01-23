    using (FileStream FS = File.Open("whatever.key"))
    {
     using (TextReader TR = new StreamReader(FS))
        {
      PR = new Org.BouncyCastle.OpenSsl.PemReader(TR);
      EPKI = (Org.BouncyCastle.Asn1.Pkcs.EncryptedPrivateKeyInfo)PR.ReadObject();
     }
    }
