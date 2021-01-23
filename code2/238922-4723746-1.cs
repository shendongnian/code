    using System.Security.Cryptography;
    using System.IO;
    namespace hash
    {
        public static class Program
        {
            static void Main(string[] args)
            {
                byte[] data = new byte[10000];
                DES des = DES.Create();
                int bytesWritten = 0;
                data = Encode(data, des, out bytesWritten);
            }
    
            private static byte[] Encode(byte[] data, DES des, out int bytesWritten)
            {
                using (var input = new MemoryStream(data))
                using (var output = new MemoryStream())
                using (var csp = new DESCryptoServiceProvider())
                using (var encStream = new CryptoStream(output, csp.CreateEncryptor(des.Key, des.IV), CryptoStreamMode.Write))
                {
                    int length = 0;
                    byte[] buffer = new byte[256];
                    bytesWritten = 0;
                    while ((length = input.Read(buffer, 0, 256)) > 0)
                    {
                        if (length < 256)
                        {
                            byte[] pad = new byte[256];
                            using (var rng = RNGCryptoServiceProvider.Create())
                            {
                                rng.GetBytes(pad);
                                for (int i = 0; i < 256 - length; i++)
                                {
                                    buffer[length + i] = pad[i];
                                }
                            }
                            encStream.Write(buffer, 0, length);
                            bytesWritten += length;
                            break;
                        }
                        encStream.Write(buffer, 0, 256);
                        bytesWritten += length;
                    }
                    return output.ToArray();
                }
            }
        }
    }
