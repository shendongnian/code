    var certificateFile = @"E:\RESDE_RSA.pfx";
    var certificate = new X509Certificate2(certificateFile,"", X509KeyStorageFlags.Exportable);
    var recipientCollection = new CmsRecipientCollection();
    var bountyRecipientCertificate = DotNetUtilities.FromX509Certificate(certificate);
    var recipient = new CmsRecipient(bountyRecipientCertificate);
    recipient.EncryptionAlgorithms = new EncryptionAlgorithm[] { EncryptionAlgorithm.Aes256 };
    recipientCollection.Add(recipient);
    // now you need to actually encrypt
    using (var ctx = new TemporarySecureMimeContext ()) {
        var encrypted = ApplicationPkcs7Mime.Encrypt (ctx, recipientCollection, multipart);
        message.Body = encrypted;
    }
