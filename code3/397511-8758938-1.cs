    private static X509Certificate2 GetCertificateByThumbprint(string certificateThumbPrint, StoreLocation certificateStoreLocation) {
        X509Certificate2 certificate = null;
    
        X509Store certificateStore = new X509Store(certificateStoreLocation);
        certificateStore.Open(OpenFlags.ReadOnly);
    
    
        X509Certificate2Collection certCollection = certificateStore.Certificates;
        foreach (X509Certificate2 cert in certCollection)
        {
            if (cert.Thumbprint != null && cert.Thumbprint.Equals(certificateThumbPrint, StringComparison.OrdinalIgnoreCase))
            {
                certificate = cert;
                break;
            }
        }
    
        if (certificate == null)
        {
            Log.ErrorFormat(CultureInfo.InvariantCulture, "Certificate with thumbprint {0} not found", certificateThumbPrint);
        }
    
        return certificate;
    }
    
    public string GetServiceResponse() {
        string WebSvcEndpointConfigurationName = "WebServiceEndpoint";
        Uri webSvcEndpointAddress = new Uri("http://www.example.com/YourWebService.svc");
        string webSvcCertificateThumbPrint = "748681ca3646ccc7c4facb7360a0e3baa0894cb5";
    
        string webSvcResponse = null;
        SomeWebServiceClient webServiceClient = null;
    
        try
        {
            webServiceClient = new SomeWebServiceClient(WebSvcEndpointConfigurationName, new EndpointAddress(webSvcEndpointAddress));
            webServiceClient.ClientCredentials.ClientCertificate.Certificate = GetCertificateByThumbprint(webSvcCertificateThumbPrint, StoreLocation.LocalMachine);
    
            webSvcResponse = webServiceClient.GetServiceResponse();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            if (webServiceClient != null)
            {
                webServiceClient.Close();
            }
        }
        return webSvcResponse;
    } 
