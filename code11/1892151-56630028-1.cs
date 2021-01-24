    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.X509;
    using Org.BouncyCastle.X509.Store;
    
    using MimeKit;
    using MimeKit.Cryptography;
    
    namespace SMimeDecryptExample
    {
        class Program
        {
            static void Main (string[] args)
            {
                var message = MimeMessage.Load (args[0]);
    
                using (var ctx = new PemSecureMimeContext ()) {
                    ctx.ImportPemKey ("private-key.pem");
    
                    var encrypted = message.BodyParts.OfType<ApplicationPkcs7Mime> ().FirstOrDefault (x => x.SecureMimeType == SecureMimeType.EnvelopedData);
                    var decrypted = encrypted.Decrypt (ctx);
                }
            }
        }
        class PemSecurityMimeContext : TemporarySecureMimeContext
        {
            AsymmetricKeyParameter key;
            public PemSecurityMimeContext ()
            {
            }
            protected override AsymmetricKeyParameter GetPrivateKey (IX509Selector selector)
            {
                return key;
            }
            public void ImportPemKey (string fileName)
            {
                using (var stream = File.OpenRead (fileName)) {
                    using (var reader = new StreamReader (stream)) {
                        var pem = new PemReader (reader);
                        var keyObject = pem.ReadObject ();
				        if (keyObject is AsymmetricCipherKeyPair pair) {
					        key = pair.Private;
				        } else if (keyObject is AsymmetricKeyParameter) {
					        key = (AsymmetricKeyParameter) keyObject;
				        }
                    }
                }
            }
        }
    }
