     /// <summary>
        /// Sets the cert policy.
        /// </summary>
        private static void SetCertificatePolicy()
        {
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
        }
        /// <summary>
        /// Remotes the certificate validate.
        /// </summary>
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            Debug.WriteLine("Trusting X509Certificate '" + cert.Subject + "'");
            return true;
        }
