    XmlNodeList UserX509Certificate = xmlDoc.GetElementsByTagName("UserX509Certificate");
    byte[] rawdat = Convert.FromBase64String(UserX509Certificate[0].InnerText);
    var chain = new List<Org.BouncyCastle.X509.X509Certificate>
    {
        Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(new X509Certificate2(rawdat))
    };
    var signaturee = new PdfPKCS7(null, chain, "SHA256", false);
    _signature = signaturee;
    _signature.SetExternalDigest(Convert.FromBase64String(signature), null, "RSA");
    byte[] encodedSignature = _signature.GetEncodedPKCS7(_hash, null, null, null, CryptoStandard.CMS);
