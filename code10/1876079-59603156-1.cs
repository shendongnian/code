    public class Program
    {
        static void DumpBytes(string title, byte[] bytes)
        {
            Console.Write(title);
            foreach (byte b in bytes)
            {
                Console.Write("{0:X} ", b);
            }
    
            Console.WriteLine();
        }
    
    	static void Main(string[] args)
    	{
    		// This will convert our input string into bytes and back
    		var converter = new ASCIIEncoding();
    
    		// Get a crypto provider out of the certificate store
    		// should be wrapped in using for production code
    		var store = new X509Store("someCertStore", StoreLocation.CurrentUser);
    
    		store.Open(OpenFlags.ReadOnly);
    
    		// should be wrapped in using for production code
    		X509Certificate2 certificate = store.Certificates[0];
    
    		RSA rsa = (RSA)certificate.PrivateKey;
    		(certificate.PrivateKey as RSACng)?.Key.SetProperty(
    												new CngProperty(
    													"Export Policy",
    													BitConverter.GetBytes((int)CngExportPolicies.AllowPlaintextExport),
    													CngPropertyOptions.Persist));
    
    		string messageToSign = "This is the message I want to sign";
    		Console.WriteLine("Message: {0}", messageToSign);
    		byte[] messageToSignBytes = converter.GetBytes(messageToSign);
    
    		// need to calculate a hash for this message - this will go into the
    		// signature and be used to verify the message
    		// Create an implementation of the hashing algorithm we are going to us
    		// should be wrapped in using for production code
    		DumpBytes("Message to sign in bytes: ", messageToSignBytes);
    		HashAlgorithm hasher = new SHA1Managed();
    
    		// Use the hasher to hash the message
    		byte[] hash = hasher.ComputeHash(messageToSignBytes);
    		DumpBytes("Hash for message: ", hash);
    
    		// Now sign the hash to create a signature
    		byte[] signature = rsa.SignHash(hash, HashAlgorithmName.SHA1, RSASignaturePadding.Pss);
    		DumpBytes("Signature: ", messageToSignBytes);
    
    		// Now use the signature to perform a successful validation of the mess
    		bool validSignature = rsa.VerifyHash(hash: hash,
    											 signature: signature,
    											 hashAlgorithm: HashAlgorithmName.SHA1,
    											 padding: RSASignaturePadding.Pss);
    		Console.WriteLine("Correct signature validated OK: {0}", validSignature);
    
    		// Change one byte of the signature
    		signature[0] = 99;
    
    		// Now try the using the incorrect signature to validate the message
    		bool invalidSignature = rsa.VerifyHash(hash: hash,
    											   signature: signature,
    											   hashAlgorithm: HashAlgorithmName.SHA1,
    											   padding: RSASignaturePadding.Pss);
    
    		Console.WriteLine("Incorrect signature validated OK: {0}", invalidSignature);
    		Console.ReadKey();
    }
