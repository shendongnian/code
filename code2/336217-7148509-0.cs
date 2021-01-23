    public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
    {
     public TrustAllCertificatePolicy()
     {}
    
     public bool CheckValidationResult(ServicePoint sp,
      X509Certificate cert,WebRequest req, int problem)
     {
      return true;
     }
    }
    // this needs to be done once before the first webservice call
    System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
