    using System;
    using System.IO;
    using Org.BouncyCastle.Bcpg.OpenPgp;
    using Org.BouncyCastle.Utilities.IO;
    
    namespace PGPDecrypt
    {
        class Program
        {
            static void Main(string[] args)
            {
                DecryptFile(
                    @"path_to_encrypted_file.pgp",
                    @"path_to_secret_key.asc",
                    "your_password_here".ToCharArray(), 
                    "output.txt"
                );
            }
    
            private static void DecryptFile(
                string inputFileName,
                string keyFileName,
                char[] passwd,
                string defaultFileName)
            {
                using (Stream input = File.OpenRead(inputFileName),
                       keyIn = File.OpenRead(keyFileName))
                {
                    DecryptFile(input, keyIn, passwd, defaultFileName);
                }
            }
    
            private static void DecryptFile(
                Stream inputStream,
                Stream keyIn,
                char[] passwd,
                string defaultFileName)
            {
                inputStream = PgpUtilities.GetDecoderStream(inputStream);
    
                try
                {
                    PgpObjectFactory pgpF = new PgpObjectFactory(inputStream);
                    PgpEncryptedDataList enc;
    
                    PgpObject o = pgpF.NextPgpObject();
                    //
                    // the first object might be a PGP marker packet.
                    //
                    if (o is PgpEncryptedDataList)
                    {
                        enc = (PgpEncryptedDataList)o;
                    }
                    else
                    {
                        enc = (PgpEncryptedDataList)pgpF.NextPgpObject();
                    }
    
                    //
                    // find the secret key
                    //
                    PgpPrivateKey sKey = null;
                    PgpPublicKeyEncryptedData pbe = null;
                    PgpSecretKeyRingBundle pgpSec = new PgpSecretKeyRingBundle(
                        PgpUtilities.GetDecoderStream(keyIn));
    
                    foreach (PgpPublicKeyEncryptedData pked in enc.GetEncryptedDataObjects())
                    {
                        sKey = FindSecretKey(pgpSec, pked.KeyId, passwd);
    
                        if (sKey != null)
                        {
                            pbe = pked;
                            break;
                        }
                    }
    
                    if (sKey == null)
                    {
                        throw new ArgumentException("secret key for message not found.");
                    }
    
                    Stream clear = pbe.GetDataStream(sKey);
    
                    PgpObjectFactory plainFact = new PgpObjectFactory(clear);
    
                    PgpObject message = plainFact.NextPgpObject();
    
                    if (message is PgpCompressedData)
                    {
                        PgpCompressedData cData = (PgpCompressedData)message;
                        PgpObjectFactory pgpFact = new PgpObjectFactory(cData.GetDataStream());
    
                        message = pgpFact.NextPgpObject();
                    }
    
                    if (message is PgpLiteralData)
                    {
                        PgpLiteralData ld = (PgpLiteralData)message;
    
                        string outFileName = ld.FileName;
                        if (outFileName.Length == 0)
                        {
                            outFileName = defaultFileName;
                        }
    
                        Stream fOut = File.Create(outFileName);
                        Stream unc = ld.GetInputStream();
                        Streams.PipeAll(unc, fOut);
                        fOut.Close();
                    }
                    else if (message is PgpOnePassSignatureList)
                    {
                        throw new PgpException("encrypted message contains a signed message - not literal data.");
                    }
                    else
                    {
                        throw new PgpException("message is not a simple encrypted file - type unknown.");
                    }
    
                    if (pbe.IsIntegrityProtected())
                    {
                        if (!pbe.Verify())
                        {
                            Console.Error.WriteLine("message failed integrity check");
                        }
                        else
                        {
                            Console.Error.WriteLine("message integrity check passed");
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine("no message integrity check");
                    }
                }
                catch (PgpException e)
                {
                    Console.Error.WriteLine(e);
    
                    Exception underlyingException = e.InnerException;
                    if (underlyingException != null)
                    {
                        Console.Error.WriteLine(underlyingException.Message);
                        Console.Error.WriteLine(underlyingException.StackTrace);
                    }
                }
            }
    
            private static PgpPrivateKey FindSecretKey(PgpSecretKeyRingBundle pgpSec, long keyID, char[] pass)
            {
                PgpSecretKey pgpSecKey = pgpSec.GetSecretKey(keyID);
    
                if (pgpSecKey == null)
                {
                    return null;
                }
    
                return pgpSecKey.ExtractPrivateKey(pass);
            }
        }
    }
