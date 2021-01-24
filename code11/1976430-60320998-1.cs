    public virtual void SignDetached(IExternalSignature externalSignature, X509Certificate[] chain,
        ICollection<ICrlClient> crlList, IOcspClient ocspClient, ITSAClient tsaClient,
        int estimatedSize, PdfSigner.CryptoStandard sigtype)
    public virtual void SignDetached(IExternalSignature externalSignature, X509Certificate[] chain,
        ICollection<ICrlClient> crlList, IOcspClient ocspClient, ITSAClient tsaClient,
        int estimatedSize, PdfSigner.CryptoStandard sigtype, SignaturePolicyInfo signaturePolicy)
    public virtual void SignDetached(IExternalSignature externalSignature, X509Certificate[] chain,
        ICollection<ICrlClient> crlList, IOcspClient ocspClient, ITSAClient tsaClient,
        int estimatedSize, PdfSigner.CryptoStandard sigtype, SignaturePolicyIdentifier signaturePolicy)
