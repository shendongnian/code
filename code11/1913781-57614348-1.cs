    pdfService.ClientCredentials.ClientCertificate.Certificate = cert;
            
    pdfService.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerTrust;
                
    pdfService.ClientCredentials.ServiceCertificate.DefaultCertificate = GetCertificate("MaternumCertificateClient");
