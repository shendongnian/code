    using System;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    
    namespace MyNameSpace
    {
     class NoCheckCertificatePolicy : ICertificatePolicy
     {
      public bool CheckValidationResult (ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
      {
       return true;
      }
     }
    }
