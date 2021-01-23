    using Org.BouncyCastle.Bcpg;
    using Org.BouncyCastle.Bcpg.OpenPgp;
    using Org.BouncyCastle.Security;
    
    
    namespace BouncyCastleTest.PGP
    {
    
        // http://www.programcreek.com/java-api-examples/index.php?api=org.bouncycastle.bcpg.HashAlgorithmTags
        // http://stackoverflow.com/questions/6337985/how-to-sign-a-txt-file-with-a-pgp-key-in-c-sharp-using-bouncy-castle-library
        class SignOnly
        {
    
    
            public void SignFile(string hashAlgorithm, string fileName, System.IO.Stream privateKeyStream
                , string privateKeyPassword, System.IO.Stream outStream)
            {
    
                PgpSecretKey pgpSec = ReadSigningSecretKey(privateKeyStream);
                PgpPrivateKey pgpPrivKey = null;
    
                pgpPrivKey = pgpSec.ExtractPrivateKey(privateKeyPassword.ToCharArray());
    
    
    
    
                PgpSignatureGenerator sGen = new PgpSignatureGenerator(pgpSec.PublicKey.Algorithm, ParseHashAlgorithm(hashAlgorithm));
    
                sGen.InitSign(PgpSignature.BinaryDocument, pgpPrivKey);
    
                foreach (string userId in pgpSec.PublicKey.GetUserIds())
                {
                    PgpSignatureSubpacketGenerator spGen = new PgpSignatureSubpacketGenerator();
    
                    spGen.SetSignerUserId(false, userId);
                    sGen.SetHashedSubpackets(spGen.Generate());
                }
    
                CompressionAlgorithmTag compression = PreferredCompression(pgpSec.PublicKey);
                PgpCompressedDataGenerator cGen = new PgpCompressedDataGenerator(compression);
    
                BcpgOutputStream bOut = new BcpgOutputStream(cGen.Open(outStream));
                sGen.GenerateOnePassVersion(false).Encode(bOut);
    
                System.IO.FileInfo file = new System.IO.FileInfo(fileName);
                System.IO.FileStream fIn = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                PgpLiteralDataGenerator lGen = new PgpLiteralDataGenerator();
                System.IO.Stream lOut = lGen.Open(bOut, PgpLiteralData.Binary, file);
    
                int ch = 0;
                while ((ch = fIn.ReadByte()) >= 0)
                {
                    lOut.WriteByte((byte)ch);
                    sGen.Update((byte)ch);
                }
    
                fIn.Close();
                sGen.Generate().Encode(bOut);
                lGen.Close();
                cGen.Close();
                outStream.Close();
            }
    
    
            public static PgpSecretKeyRingBundle CreatePgpSecretKeyRingBundle(System.IO.Stream keyInStream)
            {
                return new PgpSecretKeyRingBundle(PgpUtilities.GetDecoderStream(keyInStream));
            }
    
    
            public PgpSecretKey ReadSigningSecretKey(System.IO.Stream keyInStream) 
            {
                PgpSecretKeyRingBundle pgpSec = CreatePgpSecretKeyRingBundle(keyInStream);
                PgpSecretKey key = null;
                System.Collections.IEnumerator rIt = pgpSec.GetKeyRings().GetEnumerator();
                while (key == null && rIt.MoveNext())
                {
                    PgpSecretKeyRing kRing = (PgpSecretKeyRing)rIt.Current;
                    System.Collections.IEnumerator kIt = kRing.GetSecretKeys().GetEnumerator();
                    while (key == null && kIt.MoveNext())
                    {
                        PgpSecretKey k = (PgpSecretKey)kIt.Current;
                        if (k.IsSigningKey)
                            key = k;
                    }
                }
    
                if (key == null)
                    throw new System.Exception("Wrong private key - Can't find signing key in key ring.");
                else
                    return key;
            }
    
    
    
            public static string GetDigestName(int hashAlgorithm)
            {
                switch ((Org.BouncyCastle.Bcpg.HashAlgorithmTag)hashAlgorithm)
                {
                    case Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha1:
                        return "SHA1";
                    case Org.BouncyCastle.Bcpg.HashAlgorithmTag.MD2:
                        return "MD2";
                    case Org.BouncyCastle.Bcpg.HashAlgorithmTag.MD5:
                        return "MD5";
                    case Org.BouncyCastle.Bcpg.HashAlgorithmTag.RipeMD160:
                        return "RIPEMD160";
                    case Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha256:
                        return "SHA256";
                    case Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha384:
                        return "SHA384";
                    case Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha512:
                        return "SHA512";
                    case Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha224:
                        return "SHA224";
                    case Org.BouncyCastle.Bcpg.HashAlgorithmTag.Tiger192:
                        return "TIGER";
                    default:
                        throw new Org.BouncyCastle.Bcpg.OpenPgp.PgpException("unknown hash algorithm tag in GetDigestName: " + hashAlgorithm);
                }
            }
    
    
            public static Org.BouncyCastle.Bcpg.HashAlgorithmTag ParseHashAlgorithm(string hashAlgorithm)
            {
                switch (hashAlgorithm.ToUpper())
                {
                    case "SHA1":
                        return Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha1;
                    case "MD2":
                        return Org.BouncyCastle.Bcpg.HashAlgorithmTag.MD2;
                    case "MD5":
                        return Org.BouncyCastle.Bcpg.HashAlgorithmTag.MD5;
                    case "RIPEMD160":
                        return Org.BouncyCastle.Bcpg.HashAlgorithmTag.RipeMD160;
                    case "SHA256":
                        return Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha256;
                    case "SHA384":
                        return Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha384;
                    case "SHA512":
                        return Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha512;
                    case "SHA224":
                        return Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha224;
                    case "TIGER":
                        return Org.BouncyCastle.Bcpg.HashAlgorithmTag.Tiger192;
                    default:
                        throw new Org.BouncyCastle.Bcpg.OpenPgp.PgpException("unknown hash algorithm name in ParseHashAlgorithm: " + hashAlgorithm);
                }
            }
    
    
            public static CompressionAlgorithmTag PreferredCompression(PgpPublicKey publicKey)
            {
                return CompressionAlgorithmTag.BZip2;
            }
    
        }
    
    
    }
