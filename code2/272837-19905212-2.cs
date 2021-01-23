    public class ODataService : DataService<Database>
        {
            public ODataService()
            {
                ProcessingPipeline.ProcessingRequest += ProcessingPipeline_ProcessingRequest;
            }
    
            void ProcessingPipeline_ProcessingRequest(object sender, DataServiceProcessingPipelineEventArgs e)
            {
                if (!HttpContext.Current.Request.ClientCertificate.IsPresent)
                {
                    throw new DataServiceException(401, "401 Unauthorized");
                }
    
                var cert = new X509Certificate2(HttpContext.Current.Request.ClientCertificate.Certificate);
                if (!ValidateCertificate(cert))
                {
                    throw new DataServiceException(401, "401 Unauthorized");
                }
     
                var identity = new GenericIdentity(cert.Subject, "ClientCertificate");
                var principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
            }
    
            private bool ValidateCertificate(X509Certificate2 cert)
            {
                // do some validation
            }
