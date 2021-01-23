    using System;
    using System.IO;
    using System.Security.Cryptography;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.Crypto.Parameters;
    
    namespace RSAOpensslToDotNet
    {
        class Program
        {
            static void Main(string[] args)
            {
                StreamReader sr = new StreamReader("../../privatekey.pem");
                PemReader pr = new PemReader(sr);
                AsymmetricCipherKeyPair KeyPair = (AsymmetricCipherKeyPair)pr.ReadObject();
                RSAParameters rsa = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)KeyPair.Private);
            }
        }
    }
