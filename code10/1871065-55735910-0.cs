    using System;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    namespace TestCSPSmartCard
    {
    class Program
    {
        static unsafe void Main(string[] args)
        {
            //PKI provider name comes from system registry or the output  
            //of "certutil -scinfo" command
            //The container name comes from the output of "certutil -scinfo" command
            const string 
                pkiProvider = "Microsoft Base Smart Card Crypto Provider", 
                container = "b51a653f-f451-c1d4-0841-5ace955fc101";
            try
            {
                //'123456' is the default 
                SecureString smartCardPin;
                char[] scPwd = { '1', '2', '3', '4', '5', '6' };
                fixed(char* pChars = scPwd)       
                {   
                    smartCardPin = new SecureString(pChars, scPwd.Length);       
                }
                //Construct CspParameters object. 
                //Omitting last two arguments will cause Windows to display a dialog
                //prompting user for the SmartCard PIN.
                CspParameters csp = 
                    new CspParameters(1,
                        pkiProvider,
                        container,
                        new System.Security.AccessControl.CryptoKeySecurity(),
                        smartCardPin);
                byte[] toSign = new byte[20];
                Random rnd = new Random((int)DateTime.Now.Ticks);
                rnd.NextBytes(toSign);
                Console.WriteLine("Data to sign : " + BitConverter.ToString(toSign));
                RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(csp);
                RSAPKCS1SignatureFormatter rsaSign = new RSAPKCS1SignatureFormatter(rsaCsp);
                rsaSign.SetHashAlgorithm("SHA1");
                byte[] signature = rsaSign.CreateSignature(toSign);
                Console.WriteLine();
                Console.WriteLine("Signature: " + BitConverter.ToString(signature));
                RSACryptoServiceProvider rsaCsp2 = FromPublicKey(args.FirstOrDefault());
                
                RSAPKCS1SignatureDeformatter rsaVerify = new RSAPKCS1SignatureDeformatter(rsaCsp2);
                rsaVerify.SetHashAlgorithm("SHA1");
                bool verified = rsaVerify.VerifySignature(toSign, signature);
                Console.WriteLine();
                Console.WriteLine("Signature verified [{0}]", verified);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Crypto error: " + ex.Message);
            }
            Console.WriteLine("done!");
        }
        private static RSACryptoServiceProvider FromPublicKey(string keyFile = null)
        {
            //Generated from PEM public key file using https://superdry.apphb.com/tools/online-rsa-key-converter
            const string xmlPubKey =
                @"<RSAKeyValue><Modulus>2mdYz5yV59K0PMO6HCxBA7gVWtbmNY+dwYOc14H5DTD7zQ64CHpxAQOAexFx5uQKaxIR8UjZOikOwO+NWMvQ4/DCIHu3WwK2/M07JQ3LYeeJ8L28RSfb9S7CCMvJ7sDOmVMB4otfQwqYvMri9QWYVe/9jWIyp3LezAUyFTGnA2OeMiVaZa2gsI5+v4HkuY3ZD9KIdUgp3Wt0SFTe1jRKAaqJhp8f3Lh0CRaYoukeq0XAhhh9k55o7wLCp0XZgSZzOPeuNL+at20Tx9BRcb/9odlmFoHn/0P0X57a1yKhKRGUIri3gfu2BJ2BnXOUy+iSk1VNWRixuMsxee059Gg7Uw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            if (keyFile != null)
            {
                FileInfo cerFile = new FileInfo(keyFile);
                if (cerFile.Exists)
                {
                    X509Certificate2 cert = new X509Certificate2();
                    Console.WriteLine($"Importing public key from {cerFile.FullName}");
                    cert.Import(cerFile.FullName);
                    return (RSACryptoServiceProvider)cert.PublicKey.Key;
                }
            }
            RSACryptoServiceProvider result = new RSACryptoServiceProvider();
            result.FromXmlString(xmlPubKey);
            return result;
        }
    }
    }
   
