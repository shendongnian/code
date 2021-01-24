    //message security, we need to specify both the default certificate and the client certificate.
                ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();            client.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.LocalMachine, StoreName.Root, X509FindType.FindByThumbprint, "cbc81f77ed01a9784a12483030ccd497f01be71c");
    client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, "9b8db0dfe615458ace0ae9e89fcb983c5d16f633");
                try
                {
                    var result = client.SayHello();
                    Console.WriteLine(result);
                }
                catch (Exception)
                {
                    throw;
                }
