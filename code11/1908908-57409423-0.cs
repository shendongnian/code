    public static byte[] GetRaw(byte[] input)
    {
    	SignerInfo signerInfo = GetSignerInfo(input);
    	return signerInfo?.EncryptedDigest?.GetOctets();
    }
    private static SignerInfo GetSignerInfo(byte[] input)
    {
    	Asn1InputStream cmsInputStream = new Asn1InputStream(input);
    	Asn1Object asn1Object = cmsInputStream.ReadObject();
    
    	Asn1Sequence asn1Sequence = Asn1Sequence.GetInstance(asn1Object);
    	SignedData signedData = GetSignedData(asn1Sequence);
    	SignerInfo signerInfo = GetSignerInfo(signedData);
    	if (signerInfo?.UnauthenticatedAttributes != null)
    	{
    		signedData = GetSignerInfo(signerInfo);
    		signerInfo = GetSignerInfo(signedData);
    	}
    	return signerInfo;
    }
    private static SignerInfo GetSignerInfo(SignedData signedData)
    {
    	Asn1Encodable[] Asn1Encodables = signedData?.SignerInfos?.ToArray();
    	if (Asn1Encodables != null)
    	{
    		if (Asn1Encodables.Length > 0)
    		{
    			SignerInfo signerInfo = SignerInfo.GetInstance(Asn1Encodables[0]);
    			return signerInfo;
    		}
    	}
    	return null;
    }
    private static SignedData GetSignedData(Asn1Sequence sequence)
    {
    	var rootContent = ContentInfo.GetInstance(sequence);
    	var signedData = SignedData.GetInstance(rootContent.Content);
    	return signedData;
    }
    private static SignedData GetSignerInfo(SignerInfo signerInfo)
    {
    	Asn1Encodable[] asn1Encodables = signerInfo.UnauthenticatedAttributes.ToArray();
    	foreach (var asn1Encodable in asn1Encodables)
    	{
    		Asn1Sequence sequence = Asn1Sequence.GetInstance(asn1Encodable);
    		DerObjectIdentifier OID = (DerObjectIdentifier)sequence[0];
    		if (OID.Id == "1.2.840.113549.1.9.16.2.14")
    		{
    			Asn1Sequence newSequence =Asn1Sequence.GetInstance(Asn1Set.GetInstance(sequence[1])[0]);
    			SignedData signedData = GetSignedData(newSequence);
    			return signedData;
    		}
    	}
    	return null;
    }
