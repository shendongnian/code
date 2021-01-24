class Program
{
	public static string GetDelegatedToken()
	{
		string token = null;
		using (HttpClient hc = new HttpClient())
		{
			hc.DefaultRequestHeaders.TryAddWithoutValidation("Cache-Control", "no-cache");
			var body = new List<KeyValuePair<string, string>>();
			body.Add(new KeyValuePair<string, string>("grant_type", "password"));
			// Set scope
			body.Add(new KeyValuePair<string, string>("scope", "User.Read"));
			// The app id of the app you registered in Azure AD
			body.Add(new KeyValuePair<string, string>("client_id", "dc17****-****-****-****-****a5e7"));
			// The secret you created in your app
			body.Add(new KeyValuePair<string, string>("client_secret", "/pG******************32"));
			// Change it with your own user id
			body.Add(new KeyValuePair<string, string>("username", "jack@hanxia.onmicrosoft.com"));
			body.Add(new KeyValuePair<string, string>("password", "your password"));
			// Change e4c9ab4e-bd27-40d5-8459-230ba2a757fb with your tenant id
			var result = hc.PostAsync("https://login.microsoftonline.com/e4c9ab4e-bd27-40d5-8459-230ba2a757fb/oauth2/v2.0/token", new FormUrlEncodedContent(body)).Result;
			var json = JsonConvert.DeserializeObject<JObject>(result.Content.ReadAsStringAsync().Result);
			token = json["access_token"].ToString();
		}
		return token;
	}
	static void Main(string[] args)
	{
		using (HttpClient hc = new HttpClient())
		{
			hc.DefaultRequestHeaders.TryAddWithoutValidation("Cache-Control", "no-cache");
			hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetDelegatedToken());
			var result = hc.GetAsync("https://graph.microsoft.com/v1.0/users/jack@hanxia.onmicrosoft.com").Result;
			result.Content.CopyToAsync(Console.OpenStandardOutput()).GetAwaiter().GetResult();
		}
		Console.WriteLine();
	}
}
Response:
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/3wfm5.png
  [2]: https://i.stack.imgur.com/4Gecz.png
