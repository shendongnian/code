    X509Certificate signer = CertOpen("MyCustomRoot");
    if (signer == null) {
        throw new CryptographicException("Signer not found");
    }
    String base64str = Convert.ToBase64String(signer.RawData);
    signerCertificate.Initialize(false, X509PrivateKeyVerify.VerifySilent, EncodingType.XCN_CRYPT_STRING_BASE64, base64str);
    <...>
    // put issuer directly from issuer cert:
    issuer.Encode(signer.Subject, X500NameFlags.XCN_CERT_NAME_STR_NONE);
    <...>
    cert.InitializeFromPrivateKey(X509CertificateEnrollmentContext.ContextUser, privateKey, "");
    // this line MUST be called AFTER IX509CertificateRequestCertificate.InitializeFromPrivateKey call,
    // otherwise you will get OLE_E_BLANK uninitialized object error.
    cert.SignerCertificate = signerCertificate;
    
