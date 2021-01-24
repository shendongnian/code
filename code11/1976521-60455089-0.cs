CSharp
/// <summary>
/// implementation of signing and validation stores, 
/// loads X509Certificate from the KeyVault
/// </summary>
public class CredentialStore : ISigningCredentialStore, IValidationKeysStore
{
	private readonly KeyVaultAccessImpl kva;
	public CredentialStore(KeyVaultAccessImpl kva)
	{
		this.kva = kva;
		loadedCertificate = new Lazy<X509Certificate2>(() => LoadCertificate());
	}
	public Task<SigningCredentials> GetSigningCredentialsAsync()
	{
		return Task.Run(() => Load());
	}
	public Task<IEnumerable<SecurityKeyInfo>> GetValidationKeysAsync()
	{
		var credential = Load();
		var keyInfo = new SecurityKeyInfo
		{
			Key = credential.Key,
			SigningAlgorithm = credential.Algorithm
		};
		var res = (IEnumerable<SecurityKeyInfo>) new[] { keyInfo };
		return Task.FromResult(res);
	}
	X509Certificate2 LoadCertificate()
	{
		var cert = kva.LoadCertificate().Result;
		if (!cert.HasPrivateKey)
			throw new ArgumentException($"no private key for certificate {cert.Thumbprint} was found");
		return cert;
	}
	Lazy<X509Certificate2> loadedCertificate;
	SigningCredentials Load(string signingAlgorithm = SecurityAlgorithms.RsaSha256)
	{
		var key = new X509SecurityKey(loadedCertificate.Value);
		key.KeyId += signingAlgorithm;
		
		return new SigningCredentials(key, signingAlgorithm);
	}
}
