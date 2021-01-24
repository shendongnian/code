    class Program
    {
        static void Main(string[] args)
        {
            // your data you want to securely send from B to A without revealing the content
            byte[] data = new byte[] { 1, 2, 3, 4, 5, 6 };
            // side A
            System.Security.Cryptography.RSACryptoServiceProvider full_rsa = new System.Security.Cryptography.RSACryptoServiceProvider(1024);
            byte[] publickey = full_rsa.ExportCspBlob(false);
            // send the public key to B
            // send(publickey)...
            // side B
            //send encrypted data back to side A
            byte[] encrypteddata = EncryptData(publickey, data); 
            // side A
            // decrypt the data encryped by side B
            byte[] decrypteddata = DecryptData(full_rsa, encrypteddata); 
            
            // decrypteddata = 1,2,3,4,5,6
        }
        public static byte[] DecryptData(System.Security.Cryptography.RSACryptoServiceProvider full_rsa, byte[] data)
        {
            System.IO.BinaryReader br = new System.IO.BinaryReader(new System.IO.MemoryStream(data));
            int encryptedkeylength = br.ReadInt32();
            int aeskeylength = br.ReadInt32();
            int aesivlength = br.ReadInt32();
            byte[] encryptedaeskey = br.ReadBytes(encryptedkeylength);
            byte[] encrypteddata = br.ReadBytes( (int)(data.Length - br.BaseStream.Position));
            br.Close();
            byte[] decryptedkey = full_rsa.Decrypt(encryptedaeskey, false);
            br = new System.IO.BinaryReader(new System.IO.MemoryStream(decryptedkey));
            using (System.Security.Cryptography.Aes myAes = System.Security.Cryptography.Aes.Create())
            {
                byte[] aeskey = br.ReadBytes(aeskeylength);
                byte[] aesiv = br.ReadBytes(aesivlength);
                System.Security.Cryptography.ICryptoTransform decryptor = myAes.CreateDecryptor(aeskey, aesiv);
                using (System.IO.MemoryStream msDecrypt = new System.IO.MemoryStream())
                {
                    using (System.Security.Cryptography.CryptoStream csEncrypt = new System.Security.Cryptography.CryptoStream(msDecrypt, decryptor, System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(csEncrypt))
                        {
                            bw.Write(encrypteddata);
                        }
                        return msDecrypt.ToArray();
                    }
                }
            }
        }
        public static byte[] EncryptData(byte[] publickey, byte[] data)
        {
            using (System.Security.Cryptography.Aes myAes = System.Security.Cryptography.Aes.Create())
            {
                System.Security.Cryptography.ICryptoTransform encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV);
                using (System.IO.MemoryStream msEncrypt = new System.IO.MemoryStream())
                {
                    using (System.Security.Cryptography.CryptoStream csEncrypt = new System.Security.Cryptography.CryptoStream(msEncrypt, encryptor, System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        System.IO.MemoryStream headerms = new System.IO.MemoryStream();
                        System.IO.BinaryWriter headerbw = new System.IO.BinaryWriter(headerms);
                        using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(csEncrypt))
                        {
                            System.Security.Cryptography.RSACryptoServiceProvider public_key = new System.Security.Cryptography.RSACryptoServiceProvider(1024);
                            public_key.ImportCspBlob(publickey);
                            byte[] encryptedkey = public_key.Encrypt(Combine(myAes.Key, myAes.IV), false);
                            headerbw.Write(encryptedkey.Length);
                            headerbw.Write(myAes.Key.Length);
                            headerbw.Write(myAes.IV.Length);
                            headerbw.Write(encryptedkey);
                            headerbw.Flush();
                            bw.Write(data);
                        }                            
                        
                        byte[] result = Combine(headerms.ToArray(), msEncrypt.ToArray());
                        headerbw.Close();
                        return result;
                    }
                }
            }
        }
        static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }
    }
