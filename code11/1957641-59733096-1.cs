    List<String> names = fields.GetSignatureNames();
    foreach (String name in names)
    {
        PdfDictionary signatureDictionary = fields.GetSignatureDictionary(name);
        PdfString contents = signatureDictionary.GetAsString(PdfName.CONTENTS);
        CmsSignedData signedData = new CmsSignedData(contents.GetOriginalBytes());
        IX509Store certs = signedData.GetCertificates("COLLECTION");
        foreach (SignerInformation signerInformation in signedData.GetSignerInfos().GetSigners())
        {
            ArrayList certList = new ArrayList(certs.GetMatches(signerInformation.SignerID));
            X509Certificate certificate = (X509Certificate)certList[0];
            addLtvForChain(certificate, ocspClient, crlClient, getSignatureHashKey(signatureDictionary, encrypted));
        }
    }
