public string Sign(string dataToSign)
{
    // Default to SHA1; required if targeting .Net Framework 4.7.1 or above
    AppContext.SetSwitch("Switch.System.Security.Cryptography.Pkcs.UseInsecureHashAlgorithms", true);
    // The dataToSign byte array holds the data to be signed.
    ContentInfo contentInfo = new ContentInfo(Encoding.Unicode.GetBytes(dataToSign));
    // Create a new, nondetached SignedCms message.
    SignedCms signedCms = new SignedCms(contentInfo, false);
    X509Certificate2 cert = GetCertificate();
    CmsSigner signer = new CmsSigner(cert);
    // Sign the message.
    signedCms.ComputeSignature(signer);
    // Encode the message.
    var encoded = signedCms.Encode();
    // mimic default EncodingType; CAPICOM_ENCODE_BASE64 Data is saved as a base64 - encoded string.
    return Convert.ToBase64String(encoded, Base64FormattingOptions.InsertLineBreaks);
}
Summary of changes:
    AppContext.SetSwitch("Switch.System.Security.Cryptography.Pkcs.UseInsecureHashAlgorithms", true);
If .NET Framework 4.7.1+ is targeted (my app is targeting .NET 4.7.1) SHA256 is enabled by default for these operations. This change is necessary because SHA1 is no longer considered to be secure. [Source][1]
  [1]: https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/retargeting/4.7-4.7.1#security
    ContentInfo contentInfo = new ContentInfo(Encoding.Unicode.GetBytes(dataToSign));
Changed from Encoding UTF8 to Unicode.
    return Convert.ToBase64String(encoded, Base64FormattingOptions.InsertLineBreaks);
Use the line breaks option to match Capicom output.
