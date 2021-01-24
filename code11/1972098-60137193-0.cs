csharp
public void Main()
{
    var asymmetricCipherKeyPair = ReadAsymmetricCipherKeyPairFromPem("./key.pem");
    var signature = GetSignature(asymmetricCipherKeyPair.Private, "Some message");
}
private string GetSignature(AsymmetricKeyParameter privateKeyParameter, string message)
{
    var signer = SignerUtilities.GetSigner("SHA-256withECDSA");
    signer.Init(true, privateKeyParameter);
    signer.BlockUpdate(Encoding.ASCII.GetBytes(message), 0, Encoding.ASCII.GetBytes(message).Length);
    var signature = signer.GenerateSignature();
    
    return Convert.ToBase64String(signature);
}
private AsymmetricCipherKeyPair ReadAsymmetricCipherKeyPairFromPem(string pathToPem)
{
    using var reader = File.OpenText(pathToPem); 
    var keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
    return keyPair;
}
  [1]: https://stackoverflow.com/users/589259/maarten-bodewes
  [2]: https://www.nuget.org/packages/BouncyCastle.NetCore/
