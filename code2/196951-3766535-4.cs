     /// <summary>
        /// Sets the cert policy.
        /// </summary>
        private static void SetCertificatePolicy()
        {
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
        }
        /// <summary>
        /// Certificate validation callback 
        /// </summary>
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            if (error == SslPolicyErrors.None)
            {
               return true;   // already determined to be valid
            }
            switch (cert.GetCertHashString())
            {
               // thumbprints/hashes of allowed certificates (uppercase)
               case "066CF9CAD814DE2097D368F22D3A7D398B87C4D6":
               case "5B82C96685E3A20079B8CE7AFA32554D55DB9611":
                  Debug.WriteLine("Trusting X509Certificate '" + cert.Subject + "'");
                  return true;
               default:
                  return false;
            }
        }
