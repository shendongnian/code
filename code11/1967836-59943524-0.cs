        using System;
        using System.Security.Cryptography.X509Certificates;
    
        namespace Test
        {
       
        public class Program
        {
           public static X509Store store;
            static void Main(string[] args)
            {
    
                var cert = @"CN=, OU=..., OU=.., E=...";
                var signedCer = GetCertificateFromStoreBySubject(cert, StoreName.My, StoreLocation.CurrentUser);
    
                //Checks cert is not null and cert can be exported 
                if (signedCer!=null && CheckCertificateIsExportable(signedCer,X509ContentType.Cert))
                    {
                        var rsapk = signedCer.GetRSAPrivateKey();
                        var rsaParameter = rsapk.ExportParameters(false);
                    store.Close();
                    }
                    
              
    
            }
            public static bool CheckCertificateIsExportable(X509Certificate2 certForCheck, X509ContentType certType)
            {
                try
                {
                    certForCheck.Export(certType);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            public static X509Certificate2 GetCertificateFromStoreBySubject(string certName, StoreName sname, StoreLocation sLoc)
            {
               store  = new X509Store(sname, sLoc);
                try
                {
                    store.Open(OpenFlags.MaxAllowed);
    
                    X509Certificate2Collection certCollection = store.Certificates;
                    X509Certificate2Collection currentCerts = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                    X509Certificate2Collection signingCert = currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, false);
                    if (signingCert.Count == 0)
                        throw new InvalidOperationException();
                    return signingCert[0];
                }
                finally
                {
                    //
                }
            }
    
    
        }
    }
    
    
