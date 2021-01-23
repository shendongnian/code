    public static string EncryptString(string clearText, X509Certificate2 cert)
    {
    	try
    	{
    		byte[] encodedCypher = EncryptData(Encoding.UTF8.GetBytes(clearText), cert);
    		string cipherText = Convert.ToBase64String(encodedCypher);
    
    		return cipherText;
    	}
    	catch (Exception ex)
    	{
    		throw new EncryptionException("Could not Encrypt String. See InnerException for details.", ex);
    	}
    }
    
    private static byte[] EncryptData(byte[] clearText, X509Certificate2 cert)
    {
    	ContentInfo payloadInfo = new ContentInfo(clearText);
    	EnvelopedCms payloadEnvelope = new EnvelopedCms(payloadInfo);
    	CmsRecipient certHandle = new CmsRecipient(cert);
    	payloadEnvelope.Encrypt(certHandle);
    	return payloadEnvelope.Encode();
    }
