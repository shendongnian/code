    namespace testopenssl2
    {
    class Program
    {
 
        public static byte[] AsymmetricEncrypt(string publicKeyAsPem, byte[] payload)
        {
            CryptoKey d = CryptoKey.FromPublicKey(publicKeyAsPem, null);
            RSA rsa = d.GetRSA();
            byte[] result = rsa.PublicEncrypt(payload, RSA.Padding.PKCS1);
            rsa.Dispose();
            return result;
        }
        public static byte[] AsymmetricDecrypt(string privateKeyAsPem, byte[] payload)
        {
            //CryptoKey d = CryptoKey.FromPrivateKey(privateKeyAsPem, null);
            CryptoKey d = CryptoKey.FromPrivateKey(privateKeyAsPem, "pass");
            RSA rsa = d.GetRSA();
            byte[] result = rsa.PrivateDecrypt(payload, RSA.Padding.PKCS1);
            rsa.Dispose();
            return result;
        }
        static void Main(string[] args)
        {
            String t = @"-----BEGIN PUBLIC KEY-----
    MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCbhcU+fhYmYLESZQAj1hKBXsNY
    si0kYHNkxpP7ftxZiTFowWUVXHzQgkcYiCNnp3pt1eG6Vt0WDzyFYXqUUqugvX41
    gkaIrKQw/sRiWEx49krcz7Vxr3dufL6Mg3eK7NyWDGsqwFrx/qVNqdhsHg12PGNx
    IMY4UBtxin2A8pd4OwIDAQAB
    -----END PUBLIC KEY-----";
            String p = @"-----BEGIN RSA PRIVATE KEY-----
    Proc-Type: 4,ENCRYPTED
    DEK-Info: DES-EDE3-CBC,0A128C2617BD2EB1
    pTDtXB+mockO7fvVqn4fwGnSb1Zv3HaMAALtpiB7Rn64eAHL7psKQIIM3qoshDWF
    XgXDdTnMOGO7wtYkd9R7iJYxgt19EuEdtu2SLLXQuN4ll+JSR2R/34dF19iMXI30
    d3pe7obTIwKdyRGuu8GgEm6bGai4pkqptP0HRA6qdMI2+Qfl9+VqUuvIm7tfpIRd
    /ZLENe756IrGDvI7lGx39Md/H2sgAJsWkSYubhmtxVJ0IEvbPuKDC5V5oLyTOoy+
    6sc6ly57C4XHaTLhAKnYEvZAddnXg/e/VtfmTpqKx3n7D6FAKo1RjAjeZqEvefZd
    XAhh19YhZq3mdZNYUt7ojUarf/q3zrtTMLUxHdR0Be/VaQC5AE0d6quKyUQgxiti
    XNRS8xk9IJJqJLFSHO3ET+oTfcs+kLPuUDHqq0hY/OgW/THcDgPY1cDwtOX9yuI3
    YDoFTb3SXzRTmk2ui33f96wNPwzIAp9+TJzITxJYbF233Pz4YWuabrFuoNWZnwtT
    E/o6wcGfvAXTQkAKzwfLbTDmg5SSiGokoEcgm7qpfmQxKdmV1LmbW88DuAgdWggm
    Qf3ydZ2IrrtD1o+XP7JraeVOql0OK77pJh/bcr3bLiAT8YtsQUZLnOjkbDc3F1zW
    BGr6eeqUHxY6cqKieokhl9cBBjWuxJQL2h997svBufWdNOjTA4+32lXzDzi7bUxC
    xzIqZ7nm3YC2zUjla/l3Smz5KitqU5Y3Q9URpXOW+qMiPxmTHYOEcRDy9yh2U4iA
    CoTD6q0ZNJLEo3EVcDB+26O663/mQLuR69xstUgqHpSzGvXbqrmezA==
    -----END RSA PRIVATE KEY-----";
            
            System.Text.Encoding enc = System.Text.Encoding.ASCII;
            String s = "hello";
            byte[] payload = enc.GetBytes(s);
            Console.WriteLine("s: {0}", s);
            byte[] byte_encData = AsymmetricEncrypt(t,payload);
            
            String res;
            res = Convert.ToBase64String(byte_encData);
            Console.WriteLine("encypted: {0}", res);
            byte[] byte_decrypted = AsymmetricDecrypt(p, byte_encData);
            String res_unenc;
            res_unenc = Convert.ToBase64String(byte_decrypted);
            // works!
            Console.WriteLine("decrypted: {0}", res_unenc);
        }
        }
    }
