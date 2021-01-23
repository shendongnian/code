    var aes= new AesCryptoServiceProvider()
                        {
                            Key = PrivateKey,
                            Mode = CipherMode.CBC,
                            Padding = PaddingMode.PKCS7
                        };
    
                        //get first 16 bytes of IV and use it to decrypt
                        var iv = new byte[16];
                        Array.Copy(input, 0, iv, 0, iv.Length);
    
                        using (var ms = new MemoryStream())
                        {
                            using (var cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, iv), CryptoStreamMode.Write))
                            using (var binaryWriter = new BinaryWriter(cs))
                            {
                                //Decrypt Cipher Text from Message
                                binaryWriter.Write(
                                    input,
                                    iv.Length,
                                    input.Length - iv.Length
                                );
                            }
    
                            return Encoding.Default.GetString(ms.ToArray());
                        }
