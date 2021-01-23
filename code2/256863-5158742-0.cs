    byte[] msg = System.Text.Encoding.ASCII.GetBytes("text to encrypt");
            OpenSSL.Crypto.RSA rsa = new OpenSSL.Crypto.RSA();
           
            byte[]result = rsa.PrivateEncrypt(msg, OpenSSL.Crypto.RSA.Padding.None);
            
            Console.WriteLine(Convert.ToBase64String(result));
