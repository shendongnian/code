            using (Rijndael myRijndael = Rijndael.Create())
            {
                //Create keys
                try
                {
                    byte[] key;
                    byte[] iv;
                    key = new byte[32];
                    iv = new byte[16];
                    key = myRijndael.Key;
                    iv = myRijndael.IV;
                    using (FileStream fs = File.Create("yyy.txt"))
                    {
                        fs.Write(key, 0, key.Length);
                        fs.Write(iv, 0, iv.Length);
                    }
                    using (FileStream ms = File.Open("yyy.txt", FileMode.Open))
                    {
                        key = new byte[32];
                        iv = new byte[16];
                        ms.Read(key, 0, 32);
                        ms.Read(iv, 0, 16);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
