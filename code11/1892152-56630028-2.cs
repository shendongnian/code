    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    
    using Org.BouncyCastle.Cms;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.X509;
    using Org.BouncyCastle.X509.Store;
    
    namespace SMimeDecryptExample
    {
        class Program
        {
            static void Main (string[] args)
            {
                AsymmetricKeyParameter key;
    
                using (var stream = File.OpenRead ("private-key.pem")) {
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
    
                var encryptedData = File.ReadAllBytes (args[0]);
                var parser = new CmsEnvelopedDataParser (encryptedData);
    			var recipients = parser.GetRecipientInfos ();
                byte[] decryptedData;
    
                foreach (RecipientInformation recipient in recipients.GetRecipients ()) {
    				decryptedData = recipient.GetContent (key);
                    break;
    			}
    
                // now you can do whatever you want with the decrypted data
            }
        }
    }
