        /// <summary>
        /// use a private key to generate a secure license file. the private key must match the public key accessible to
        /// the system validating the license.
        /// </summary>
        /// <param name="start">applicable start date for the license file.</param>
        /// <param name="end">applicable end date for the license file</param>
        /// <param name="productName">applicable product name</param>
        /// <param name="userName">user-name</param>
        /// <param name="privateKey">the private key (in XML form)</param>
        /// <returns>secure, public license, validated with the public part of the key</returns>
        public static License CreateLicense(DateTime start, DateTime end, String productName, String userName, String privateKey)
        {
            // create the licence terms:
            LicenseTerms terms = new LicenseTerms()
            {
                StartDate = start,
                EndDate = end,
                ProductName = productName,
                UserName = userName
            };
            // create the crypto-service provider:
            DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
            // setup the dsa from the private key:
            dsa.FromXmlString(privateKey);
            // get the byte-array of the licence terms:
            byte[] license = terms.GetLicenseData();
            // get the signature:
            byte[] signature = dsa.SignData(license);
            // now create the license object:
            return new License()
            {
                LicenseTerms = Convert.ToBase64String(license),
                Signature = Convert.ToBase64String(signature)
            };
        }
