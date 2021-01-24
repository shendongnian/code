    using System;
    using System.IO;
    using System.Text;
    using Org.BouncyCastle.Crypto.Digests;
    using Org.BouncyCastle.Crypto.Encodings;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.OpenSsl;
    
    namespace ScratchPad
    {
        class MainClass
        {
            public static void OaepEncryptExample()
            {
                var plain = Encoding.UTF8.GetBytes("The sun also rises.");
                // Read in public key from file
                var pemReader = new PemReader(File.OpenText(@"/Users/horton/tmp/key-examples/myserver_pub.pem"));
                var rsaPub = (Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters)pemReader.ReadObject();
                // create encrypter
                var encrypter = new OaepEncoding(new RsaEngine(), new Sha256Digest(), new Sha256Digest(), null);
                encrypter.Init(true, rsaPub);
                var cipher = encrypter.ProcessBlock(plain, 0, plain.Length);
                Console.WriteLine(Convert.ToBase64String(cipher));
            }
        }
    }
