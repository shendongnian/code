        /// <summary>
        /// validate license file and return the license terms.
        /// </summary>
        /// <param name="license"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        internal static LicenseTerms GetValidTerms(License license, String publicKey)
        {
            // create the crypto-service provider:
            DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
            // setup the provider from the public key:
            dsa.FromXmlString(publicKey);
            // get the license terms data:
            byte[] terms = Convert.FromBase64String(license.LicenseTerms);
            // get the signature data:
            byte[] signature = Convert.FromBase64String(license.Signature);
            // verify that the license-terms match the signature data
            if (dsa.VerifyData(terms, signature))
                return LicenseTerms.FromString(license.LicenseTerms);
            else
                throw new SecurityException("Signature Not Verified!");
        }
