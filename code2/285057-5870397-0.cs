            byte[] key = { 4, 5, 6 }; // Where to store these keys is the tricky part, you may need to obfuscate them or get the user to input a password each time
            byte[] iv = { 1, 2, 3 };
            string path = @"p:\\ath\to.file";
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            using (var fs = new FileStream(path, FileMode.Create))
            {
                var cryptoStream = new CryptoStream(fs, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                // This is where you serialize the class
                formatter.Serialize(cryptoStream, customClass);
            }
