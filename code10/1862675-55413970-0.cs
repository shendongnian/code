               var trust = new X509Certificate2("serverCert.p12","myPwd");
               var key = new X509Certificate2("clientCert.p12","myPwd");
               var clientCertificateCollection = new X509CertificateCollection(new X509Certificate[] { trust,key });
                
               ssl.AuthenticateAsClient(host, clientCertificateCollection, SslProtocols.Tls12, false);
