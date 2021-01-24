    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    
    using MimeKit;
    using MimeKit.Cryptography;
    
    namespace SMimeDecryptExample
    {
        class Program
        {
            static void Main (string[] args)
            {
                var message = MimeMessage.Load (args[0]);
    
                using (var ctx = new TemporarySecureMimeContext ()) {
                    ctx.Import ("private-key.pem", "password");
    
                    var encrypted = message.BodyParts.OfType<ApplicationPkcs7Mime> ().FirstOrDefault (x => x.SecureMimeType == SecureMimeType.EnvelopedData);
                    var decrypted = encrypted.Decrypt (ctx);
                }
            }
        }
    }
