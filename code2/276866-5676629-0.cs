    using System;
    using System.Xml;
    using System.IO;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Xml;
    using System.Text;
    
    using Org.BouncyCastle.Bcpg.OpenPgp;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.Utilities.IO;
    using Org.BouncyCastle.Utilities.Encoders;
    using Org.BouncyCastle.Bcpg;
    
    class Program
    {
        private static PgpPublicKey ReadPublicKey(Stream inputStream)
        {
          
            inputStream = PgpUtilities.GetDecoderStream(inputStream);
    
            PgpPublicKeyRingBundle pgpPub = new PgpPublicKeyRingBundle(inputStream);
    
            //
            // we just loop through the collection till we find a key suitable for encryption, in the real
            // world you would probably want to be a bit smarter about this.
            //
    
            //
            // iterate through the key rings.
            //
    
            foreach (PgpPublicKeyRing kRing in pgpPub.GetKeyRings())
            {
                foreach (PgpPublicKey k in kRing.GetPublicKeys())
                {
                    if (k.IsEncryptionKey)
                    {
                        return k;
                    }
                }
            }
    
            throw new ArgumentException("Can't find encryption key in key ring.");
        }
    
        private static byte[] EncryptFile(byte[] clearData, string fileName, PgpPublicKey encKey, bool withIntegrityCheck)
        {
    
            MemoryStream bOut = new MemoryStream();
    
            PgpCompressedDataGenerator comData = new PgpCompressedDataGenerator(
                CompressionAlgorithmTag.Zip);
    
            Stream cos = comData.Open(bOut); // open it with the final destination
            PgpLiteralDataGenerator lData = new PgpLiteralDataGenerator();
    
            // we want to Generate compressed data. This might be a user option later,
            // in which case we would pass in bOut.
            Stream pOut = lData.Open(
                cos,					// the compressed output stream
                PgpLiteralData.Binary,
                fileName,				// "filename" to store
                clearData.Length,		// length of clear data
                DateTime.UtcNow			// current time
            );
    
            pOut.Write(clearData, 0, clearData.Length);
    
            lData.Close();
            comData.Close();
    
            PgpEncryptedDataGenerator cPk = new PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag.Cast5, new SecureRandom());
    
            cPk.AddMethod(encKey);
    
            byte[] bytes = bOut.ToArray();
    
            MemoryStream encOut = new MemoryStream();
            Stream os = encOut;
    
            Stream cOut = cPk.Open(os, bytes.Length);
            cOut.Write(bytes, 0, bytes.Length);  // obtain the actual bytes from the compressed stream
            cOut.Close();
    
            encOut.Close();
    
            return encOut.ToArray();
        }
    
        static void Main(string[] args)
        {
            try
            {
                byte[] dataBytes = File.ReadAllBytes("test.xml");
                Stream keyIn = File.OpenRead("cert.asc");
                Stream outStream = File.Create("data.bpg");
                byte[] encrypted = EncryptFile(dataBytes, "data", ReadPublicKey(keyIn), false);
                outStream.Write(encrypted, 0, encrypted.Length);
                keyIn.Close();
                outStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
