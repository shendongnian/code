class Program
{
	static string azureDevOpsOrganizationUrl = "https://dev.azure.com/jack0503/"; //change to the URL of your Azure DevOps account; NOTE: This must use HTTPS
	static string clientId = "0a1f****-****-****-****-a2a4****7f69";          //change to your app registration's Application ID
	static string replyUri = "https://localhost/";                     //change to your app registration's reply URI
	static string azureDevOpsResourceId = "499b84ac-1321-427f-aa17-267ca6975798"; //Constant value to target Azure DevOps. Do not change  
	static string tenant = "hanxia.onmicrosoft.com";     //your tenant ID or Name
	static String GetTokenInteractively()
	{
		AuthenticationContext ctx = new AuthenticationContext("https://login.microsoftonline.com/" + tenant); ;
		IPlatformParameters promptBehavior = new PlatformParameters(PromptBehavior.Auto | PromptBehavior.SelectAccount);
		AuthenticationResult result = ctx.AcquireTokenAsync(azureDevOpsResourceId, clientId, new Uri(replyUri), promptBehavior).Result;
		return result.AccessToken;
	}
	static String GetToken()
	{
		AuthenticationContext ctx = new AuthenticationContext("https://login.microsoftonline.com/" + tenant); ;
		UserPasswordCredential upc = new UserPasswordCredential("jack@hanxia.onmicrosoft.com", "yourpassword");
		AuthenticationResult result = ctx.AcquireTokenAsync(azureDevOpsResourceId, clientId, upc).Result;
		return result.AccessToken;
	}
	static void Main(string[] args)
	{
		//string token = GetTokenInteractively();
		string token = GetToken();
		using (var client = new HttpClient())
		{
			client.BaseAddress = new Uri(azureDevOpsOrganizationUrl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			HttpResponseMessage response = client.GetAsync("_apis/projects").Result;
			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("\tSuccesful REST call");
				var result = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine(result);
			}
			else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
			{
				throw new UnauthorizedAccessException();
			}
			else
			{
				Console.WriteLine("{0}:{1}", response.StatusCode, response.ReasonPhrase);
			}
			Console.ReadLine();
		}
	}
}
  [1]: https://i.stack.imgur.com/3q3K6.png
  [2]: https://i.stack.imgur.com/Pw2dw.png
  [3]: https://i.stack.imgur.com/joJkh.png
  [4]: https://i.stack.imgur.com/Nwxho.png
