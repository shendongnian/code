    public class CustomExternalSignature : IExternalSignature
    {
        public ICollection<X509Certificate> GetChain()
        {
            [essentially your GetChain method, but return the List as is, don't make it an array]]
        }
        public string GetEncryptionAlgorithm()
        {
            return "RSA";
        }
        public string GetHashAlgorithm()
        {
            return "SHA256";
        }
        public byte[] Sign(byte[] message)
        {
            [your code to call the smart card function to sign the message using RSASSA-PKCS1-v1_5]
            [you might or might not have to hash the message first, I don't know that smart card API you use]
        }
    }
