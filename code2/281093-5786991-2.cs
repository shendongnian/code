     X509Name issuer = new X509Name("issuer");
     X509Name subject = new X509Name("subject");
     RSA rsa = new RSA();
     rsa.GenerateKeys(512,0x10021,null,null);
     CryptoKey key = new CryptoKey(rsa);
     X509Certificate cert = new X509Certificate(123, subject, issuer, key, DateTime.Now,
                                                           DateTime.Now.AddDays(200));
                
     File.WriteAllText("C:\\temp\\public.txt",rsa.PublicKeyAsPEM);
     File.WriteAllText("C:\\temp\\private.txt", rsa.PrivateKeyAsPEM);
                
     BIO bio = BIO.File("C:/temp/cert.cer", "w");
     cert.Write(bio);
