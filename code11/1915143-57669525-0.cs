    using System;
    using System.Security.Cryptography;
    
    class Program
    {
    
        static void Main(string[] args)
        {
            String pubB64 = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCK8xP3JO4exQPIB2eDpAVXasM3YOoZN405HuaSjr1FVE0Z++jKrVhTiOYqiXX7ksChmoEt4uim+tWK/1SNpMyD/nl4SsQjkG0zRJr+kfP4owDnQdZRDPpLZABI2X5O6o5bgwPsxY3UfuenwrKc1/FQRITfaTp7nyoX956EZ9v4dQIDAQAB";
            String text = "abcdefg123456";
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] publicKeyBytes = Convert.FromBase64String(pubB64);
    
            var keyLengthBits = 1024;  // need to know length of public key in advance!
            byte[] exponent = new byte[3];
            byte[] modulus = new byte[keyLengthBits / 8];
            Array.Copy(publicKeyBytes, publicKeyBytes.Length - exponent.Length, exponent, 0, exponent.Length);
            Array.Copy(publicKeyBytes, publicKeyBytes.Length - exponent.Length - 2 - modulus.Length, modulus, 0, modulus.Length);
    
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            RSAParameters rsaKeyInfo = rsa.ExportParameters(false);
            rsaKeyInfo.Modulus = modulus;
            rsaKeyInfo.Exponent = exponent;
            rsa.ImportParameters(rsaKeyInfo);
    
            byte[] encrypted = rsa.Encrypt(textBytes, RSAEncryptionPadding.Pkcs1);
            Console.WriteLine(Convert.ToBase64String(encrypted));
    
        }
    }
