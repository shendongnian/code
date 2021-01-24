      using BouncyTls = Org.BouncyCastle.Crypto.Tls;
      ...
      public override IDictionary GetClientExtensions() // Override in your TlsClient class
      {
        IDictionary clientExtensions = base.GetClientExtensions();
        clientExtensions = BouncyTls.TlsExtensionsUtilities.EnsureExtensionsInitialised(clientExtensions);
        byte type = BouncyTls.CertificateStatusType.ocsp;
        var request = new BouncyTls.OcspStatusRequest(null, null);
        BouncyTls.TlsExtensionsUtilities.AddStatusRequestExtension(clientExtensions, new BouncyTls.CertificateStatusRequest(type, request));
        return clientExtensions;
      }
