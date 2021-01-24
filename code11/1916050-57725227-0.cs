    using Org.BouncyCastle.Asn1;
    using Org.BouncyCastle.Cms;
    using Org.BouncyCastle.Pkcs;
    using Org.BouncyCastle.X509;
    using System.IO;
    
    namespace pkchwencrypting
    {
        class Program
        {
            static void Main(string[] args)
            {
                var certificateData = File.ReadAllBytes("YOUR_p7b_FILE");
                var cert = new X509CertificateParser().ReadCertificate(certificateData);
    //I just wanted to know if I can see the publicKey somehow            
    //var publicKey = cert.GetPublicKey();
    
                var store = new Pkcs12Store(File.OpenRead("YOUR_p12_File"), "test".ToCharArray());
                var privateKey = store.GetKey("THE_NAME_OF_KEY_YOU_WANT_TO_GET").Key;
    
                var signedDataGen = new CmsSignedDataGenerator();
                signedDataGen.AddSigner(privateKey, cert, CmsSignedDataGenerator.EncryptionRsa, CmsSignedDataGenerator.DigestSha512);
    
                var zipContent = new CmsProcessableFile(new FileInfo("YOUR_DATA_FILE"));
    //For me a zip
                var signedData = signedDataGen.Generate(zipContent, true);
    
                var envDataGen = new CmsEnvelopedDataGenerator();
                envDataGen.AddKeyTransRecipient(cert);
    
                var sData = new CmsProcessableByteArray(signedData.GetEncoded());
                var enveloped = envDataGen.Generate(sData, CmsEnvelopedDataGenerator.DesEde3Cbc);
    
                var dos = new DerOutputStream(File.OpenWrite("YOUR_DATA_FILE.zip.encrypted.sig)"));
                var bytesToWrite = enveloped.GetEncoded();
                dos.Write(bytesToWrite, 0, bytesToWrite.Length);
                dos.Flush();
                dos.Close();
    
             
            }
    
        }
    }
