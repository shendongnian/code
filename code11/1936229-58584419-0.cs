using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
namespace Whatever
{
    class Program
    {
        static string cert = "MIIJmQIBA.... // This here is base64 encoded PFX for the purposes of the demo ONLY";
        static string pwd = "password";
        static void Main(string[] args)
        {
            var data = Encoding.ASCII.GetBytes("Hi!");
             
            var hash = HashAlgorithm.Create("SHA256").ComputeHash(data);
            var certificate = new X509Certificate2(Convert.FromBase64String(cert), pwd);
            // So since I've no idea how you got p7s, i improvised here:
            var cms = new SignedCms(new ContentInfo(hash), true); // true -> Detached
            var signer = new CmsSigner(SubjectIdentifierType.SubjectKeyIdentifier, certificate);
            cms.ComputeSignature(signer);
            var data2 = cms.Encode();
            // assuming this was in p7s file
            var xx = Convert.ToBase64String(data2);
            // this passes, this is the .Net validation from OP
            var cms2 = new SignedCms(new ContentInfo(hash), true);
            cms2.Decode(Convert.FromBase64String(xx));
            cms2.CheckSignature(true);
            // Same in bouncy castle:
            BCUtil.Validate(certificate, hash, xx);
        }
    }
}
Here is our `BCUtil` class:
using System;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Security;
using System.IO;
using System.Linq;
namespace Whatever
{
    public class BCUtil
    {
        public static void Validate(System.Security.Cryptography.X509Certificates.X509Certificate2 cert, byte[] hash, string whatToValidate)
        {
            // My understanding is that you always need a cert to validate a signature with BC, but you only need a PUBLIC key
            var certificate = DotNetUtilities.FromX509Certificate(cert);
            // hash here
            var processable = new CmsProcessableByteArray(hash);
            // and signature here, for full .Net convert to old using() {} syntax
            using var str = new MemoryStream(Convert.FromBase64String(whatToValidate));
            var cms = new CmsSignedData(processable, str);
            var signers = cms.GetSignerInfos();
            var signersCollection = signers.GetSigners();
            
            foreach(var signer in signersCollection.Cast<SignerInformation>())
            {
                if (signer.Verify(certificate.GetPublicKey()))
                {
                    Console.WriteLine("yes banana"); // pass
                }
                else
                {
                    throw new Exception("no banana"); // fail
                }
            }
        }
    }
}
