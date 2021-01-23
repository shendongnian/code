     PgpPublicKey  PublicKey;
     var val = (RsaKeyParameters)PublicKey.GetKey();
     string ModulusVal = Convert.ToBase64String(Encoding.UTF8.GetBytes(val.Modulus.ToString()));
     string ExponentVal = Convert.ToBase64String(Encoding.UTF8.GetBytes(val.Exponent.ToString()));
    XDocument X = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                                            new XElement("RSAKeyValue",
                                                new XElement("Modulus", ModulusVal),
                                                new XElement("Exponent", ExponentVal)));
    X.Save(XMLFileSavePath, SaveOptions.None);
