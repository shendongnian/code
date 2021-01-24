    public MimeMessage SignMessage(MimeMessage message, MailboxAddress address)
    {
        using (var ctx = new TemporarySecureMimeContext ())
        {
            X509Certificate2 cert = null;
            string thumbprint = "<myThumbprint>";
            var machineStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            machineStore.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection machineCerts = machineStore.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            if (machineCerts.Count == 1)
            {
                cert = machineCerts[0];
            }
            if (cert != null)
            {
                CmsSigner signer = new CmsSigner(cert)
                {
                    RsaSignaturePaddingScheme = RsaSignaturePaddingScheme.Pss,
                    DigestAlgorithm = DigestAlgorithm.Sha256
                };
                message.Body = MultipartSigned.Create(ctx, signer, message.Body);
            }
        }
        return message;
    }
