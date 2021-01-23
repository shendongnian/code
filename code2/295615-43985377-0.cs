            public static X509Certificate2 OpenCertificate(string pfxPath, string contrasenia)
        {
            System.Security.Cryptography.X509Certificates.X509Certificate2 x509 = default(System.Security.Cryptography.X509Certificates.X509Certificate2);
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(pfxPath));
            Org.BouncyCastle.Pkcs.Pkcs12Store st = new Org.BouncyCastle.Pkcs.Pkcs12Store(ms, contrasenia.ToCharArray());
            var alias = st.Aliases.Cast<string>().FirstOrDefault(p => st.IsCertificateEntry(p));
            Org.BouncyCastle.Pkcs.X509CertificateEntry keyEntryX = st.GetCertificate(alias);
            x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2(DotNetUtilities.ToX509Certificate(keyEntryX.Certificate));
            alias = st.Aliases.Cast<string>().FirstOrDefault(p => st.IsKeyEntry(p));
            Org.BouncyCastle.Pkcs.AsymmetricKeyEntry keyEntry = st.GetKey(alias);
            System.Security.Cryptography.RSACryptoServiceProvider intermediateProvider = (System.Security.Cryptography.RSACryptoServiceProvider)Org.BouncyCastle.Security.DotNetUtilities.ToRSA((Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters)keyEntry.Key);
            x509.PrivateKey = intermediateProvider;
            return x509;
        }
