    using System;
    using System.Text;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    namespace EncryptionTest
    {
        public class Aes256Handler
        {
            private byte[] key;
            public Aes256Handler(byte[] key)
            {
                this.key = key;
            }
            public string EncryptString(string plaintext)
            {
                return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(plaintext)));
            }
            public string DecryptString(string encryptedtext)
            {
                return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(encryptedtext)));
            }
            public byte[] Encrypt(byte[] bytes)
            {
                if (bytes == null || bytes.Length < 1)
                {
                    throw new ArgumentException("Invalid bytes");
                }
                if (key == null || key.Length < 1)
                {
                    throw new InvalidOperationException("Invalid encryption settings");
                }
                byte[] encrypted;
                try
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = key;
                        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ms.Write(aes.IV, 0, aes.IV.Length);
                            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                            {
                                cs.Write(bytes, 0, bytes.Length);
                            }
                            encrypted = ms.ToArray();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                return encrypted;
            }
            public byte[] Decrypt(byte[] bytes)
            {
                if (bytes == null || bytes.Length < 1)
                {
                    throw new ArgumentException("Invalid bytes");
                }
                if (key == null || key.Length < 1)
                {
                    throw new InvalidOperationException("Invalid encryption settings");
                }
                byte[] decrypted;
                try
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = key;
                        byte[] iv = new byte[16];
                        MemoryStream ms = new MemoryStream(bytes);
                        ms.Read(iv, 0, iv.Length);
                        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, iv);
                        using (ms)
                        {
                            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[bytes.Length - iv.Length];
                                var decryptedCount = cs.Read(decrypted, 0, decrypted.Length);
                                decrypted = decrypted.Take(decryptedCount).ToArray();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                return decrypted;
            }
        }
    }
