    $code = @"
    public class SSLHandler
    {
        private static bool Callback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    
        public static System.Net.Security.RemoteCertificateValidationCallback GetSSLHandler()
        {
    
            return new System.Net.Security.RemoteCertificateValidationCallback(Callback);
        }
        
    }
    "@
