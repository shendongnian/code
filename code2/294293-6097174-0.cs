    using (AesManaged aes = new AesManaged())
    {
        //Set the Key here.
        aes.GenerateIV();
        using (var transform = aes.CreateEncryptor())
        {
            using (var fileStream = new FileStream("C:\\in.txt", FileMode.Open))
            {
                using (var saveTo = new FileStream("C:\\out.txt", FileMode.Create))
                {
                    using (var cryptoStream = new CryptoStream(saveTo, transform,CryptoStreamMode.Write))
                    {
                        var iv = aes.IV;
                        cryptoStream.Write(iv, 0, iv.Length);
                        fileStream.CopyTo(cryptoStream);
                    }
                }
            }
        }
    }
