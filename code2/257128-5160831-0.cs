     public static bool IgnoreInvalidSSL { get; set; }
        private static bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            if (IgnoreInvalidSSL)
            {
                return true;
            }
            else
            {
                return policyErrors == SslPolicyErrors.None;
            }
        }
