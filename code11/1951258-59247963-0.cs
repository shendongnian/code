    using (Ftp client = new Ftp())
                {
                    client.ServerCertificateValidate += ValidateCertificate;
                    client.Connect(Host,2121);
                    client.Login(Username, Password); 
                    client.Upload(dosyaAdi, LocalDestinationFilename);
                  }
 
