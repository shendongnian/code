    ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback( delegateHttpSsl );
        
            private bool delegateHttpSsl(object obj, System.Security.Cryptography.X509Certificate c1, System.Security.Cryptography.X509Certifciates.X509Chain c2, SslPolicyErrors c3)
            {
                  return true;
            }
