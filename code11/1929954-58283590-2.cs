        byte[] data = new byte[] { 0, 1, 2, 3, 4, 5 };
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            byte[] signature = rsa.SignData(data, "SHA256");
            if (rsa.VerifyData(data, "SHA256", signature))
            {
                  Console.WriteLine("RSA-SHA256 signature verified");
            }
             else
            {
                Console.WriteLine("RSA-SHA256 signature failed to verify");
            }
        }
