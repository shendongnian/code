     static public string RSADecrypt(string cipherText)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] DataToDecrypt = StringToByteArray(cipherText);
            bool DoOAEPPadding = false;
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    KeyInfo keyInfo = new KeyInfo();
                    RSAParameters RSAKeyInfo = keyInfo.getKey();
                    RSA.ImportParameters(RSAKeyInfo); 
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                byte[] paddedOutput = paddWithZeros(decryptedData); //to sync with as3crypto
                return (ByteConverter.GetString(paddedOutput));
    
            }catch (CryptographicException e)
            {
                //handle error
                return null;
            }
        }
