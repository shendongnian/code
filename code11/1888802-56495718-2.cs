    using System;
    using System.IO;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;
    
    namespace ScratchPad
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                var pemReader = new PemReader(File.OpenText(@"/Users/horton/tmp/key-examples/myserver_pub.pem"));
                var pemObject = (Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters)pemReader.ReadObject();
                var rsa = DotNetUtilities.ToRSA(pemObject);
                // ... more stuff ...
            }
        }
    }
