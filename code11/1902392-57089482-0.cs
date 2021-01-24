	class Program
	{
		public static string clientId = "d4c9b2ed-****-****-****-30a787f7c928";
		public static string redirectUri = "https://localhost/";
		public static string baseUrl = "https://jackkv.vault.azure.net/";
		public static async Task<string> AuthenticationCallback(string authority, string resource, string scope)
		{
			var result = await new AuthenticationContext(authority).AcquireTokenAsync(resource, clientId, new Uri(redirectUri), new PlatformParameters(PromptBehavior.RefreshSession));
			return result.AccessToken;
		}
		static void Main(string[] args)
		{
			Console.ReadLine();
			KeyVaultClient kvc = new KeyVaultClient(AuthenticationCallback);
			var secret = kvc.GetSecretAsync(baseUrl, "testSecret").Result;
			Console.WriteLine(secret.Value);
			Console.ReadLine();
		}
	}
