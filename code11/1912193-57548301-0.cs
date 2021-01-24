public class RSASHA1SignatureDescription : SignatureDescription {
        public RSASHA1SignatureDescription() {
            KeyAlgorithm = "System.Security.Cryptography.RSA";
            DigestAlgorithm = "System.Security.Cryptography.SHA1Cng";
            FormatterAlgorithm = "System.Security.Cryptography.RSAPKCS1SignatureFormatter";
            DeformatterAlgorithm = "System.Security.Cryptography.RSAPKCS1SignatureDeformatter";
            _hashAlgorithm = "SHA1";
        }
 
        public override AsymmetricSignatureDeformatter CreateDeformatter(AsymmetricAlgorithm key) {
			AsymmetricSignatureDeformatter item = (AsymmetricSignatureDeformatter) CryptoConfig.CreateFromName(DeformatterAlgorithm);
			item.setKey(key);
            item.SetHashAlgorithm(_hashAlgorithm);
            return item;
        }
 
        public override AsymmetricSignatureFormatter CreateFormatter(AsymmetricAlgorithm key) {
           	AsymmetricSignatureFormatter item = (AsymmetricSignatureFormatter) CryptoConfig.CreateFromName(FormatterAlgorithm);
		    item.setKey(key);
            item.SetHashAlgorithm(_hashAlgorithm);
            return item;
        }
 
        private string _hashAlgorithm;
    }
The other possibility is that however you're validating the signature doesn't want rsa-sha1 (many identity providers prohibit rsa-sha1 via configuration) or the validation is incorrect. Try registering with a real IdP such as Okta or Salesforce and validate there.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptoconfig?view=netframework-4.8
