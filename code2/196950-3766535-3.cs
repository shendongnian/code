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
               // thumbprints/hashes of allowed certificates
               case "066cf9cae814de2097d468f22d3a7d398b87c4d6":
               case "5b82c96684e3a20079b8ce7afa32254d55db9611":
                  Debug.WriteLine("Trusting X509Certificate '" + cert.Subject + "'");
                  return true;
               default:
                  return false;
            }
        }
