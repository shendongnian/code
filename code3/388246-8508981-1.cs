        private FDGGWSApiOrderService oFDGGWSApiOrderService = null;
        /// <summary>
        /// Initializes a new instance of the test version of the <see cref="ProcessCreditCard"/> class.
        /// </summary>
        /// <param name="test">if set to <c>true</c> [test].</param>
        public ProcessCreditCard()
        {
            ServicePointManager.Expect100Continue = false;
            // Initialize Service Object 
            oFDGGWSApiOrderService = new FDGGWSApiOrderService();
            // Set the WSDL URL
            oFDGGWSApiOrderService.Url = @Settings.Default.CcApiUrl;
            // Configure Client Certificate  
            oFDGGWSApiOrderService.ClientCertificates.Add(X509Certificate.CreateFromCertFile(Settings.Default.CertFile));
            // Set the Authentication Credentials
            NetworkCredential nc = new NetworkCredential(Settings.Default.CertUser, Settings.Default.CertPass);
            oFDGGWSApiOrderService.Credentials = nc;
        }
