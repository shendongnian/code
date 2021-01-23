        public static getDataResponse queryingData(string name)
        {
            proxy.BanWS conexion = new proxy.Banws();
            //VALIDATION OF CONNECTION V3
            X509Certificate2 elCert = new X509Certificate2(@"C:\portecle-1.5\12345.P12", "12345");
            conexion.ClientCertificates.Add(elCert);
            // Copy the certificate to the certificate store using ASPNET
            // spent the path and password
            X509Certificate2 certificate = new X509Certificate2(@"C:\portecle-1.5\12345.P12", "12345");
            X509Store stores = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            stores.Open(OpenFlags.ReadWrite);
            stores.Add(certificate);
            stores.Close();
            String sto = X509CertificateStore.MyStore;
            // Open the Certificates Stores
            X509CertificateStore store = X509CertificateStore.CurrentUserStore(sto);
            store.OpenRead();
            // We look for the certificate that we will use to perform the signature
            String certname = "conticert";
            
            Microsoft.Web.Services2.Security.X509.X509CertificateCollection certcoll = store.FindCertificateBySubjectString(certname);
            if (certcoll.Count != 0)
            {
                Microsoft.Web.Services2.Security.X509.X509Certificate cert = certcoll[0];
                SoapContext ctx = conexion.RequestSoapContext;
                SecurityToken tok = new X509SecurityToken(cert);
                ctx.Security.Timestamp.TtlInSeconds = 120;
                ctx.Security.Tokens.Add(tok);
                // We signed the request
                ctx.Security.Elements.Add(new MessageSignature(tok));
            }
            //remote call
            getDataResponse response = new getDataResponse();
            
            response = conexion.getData(name);
            
            return response;
        }
