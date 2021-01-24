        /// <summary>
        /// Load the certificate that sign the Id or Jw token
        /// </summary>
        /// <returns></returns>
        private static X509Certificate2 LoadCertificate()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return new X509Certificate2(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigMngr.GetAppSettingsValue<string>("IdSrv:SigningCertificatePath")), ConfigMngr.GetAppSettingsValue<string>("IdSrv:SigningCertificatePassword"));
        }
