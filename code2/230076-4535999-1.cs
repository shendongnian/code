    using System.Security.Cryptography;
    using Org.BouncyCastle.Asn1;
        public static byte[] DEREncode(RSACryptoServiceProvider rsa)
        {
            RSAParameters rsaParams = rsa.ExportParameters(false);
            DerInteger n = new DerInteger(rsaParams.Modulus);
            DerInteger e = new DerInteger(rsaParams.Exponent);
            DerSequence seq = new DerSequence(new Asn1Encodable[] {n, e});
            return seq.GetEncoded();
        }
