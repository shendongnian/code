	class Program
	{
		static void Main(string[] args)
		{
			string flag = "Y";
			IPublicClientApplication app = PublicClientApplicationBuilder.Create("60ef0838-f145-4f00-b7ba-a5af7f31cc3c").Build();
			string[] scopes = new string[] { "api://4a673722-5437-4663-bba7-5f49372e06ba/Group.All","openid" };
			do
			{
				List<IAccount> list = app.GetAccountsAsync().GetAwaiter().GetResult().ToList();
				Console.WriteLine("Checking cache");
				if (list.Count > 0)
				{
					Console.WriteLine($"Find {list.Count}");
					list.ForEach(_ =>
					{
						Console.WriteLine($"Acquire a new token for {_.Username}");
						AuthenticationResult result = app.AcquireTokenSilent(scopes, _).WithForceRefresh(true).WithAuthority("https://login.microsoftonline.com/e4c9ab4e-bd27-40d5-8459-230ba2a757fb/").ExecuteAsync().Result;
						Console.WriteLine($"New token -> {result.AccessToken}");
					});
				}
				else
				{
					Console.WriteLine("No cache");
					try
					{
						var securePassword = new SecureString();
						// Test AcquireTokenByUsernamePassword
						foreach (char c in "**********") securePassword.AppendChar(c);
						AuthenticationResult result = app.AcquireTokenByUsernamePassword(scopes, "jack@hanxia.onmicrosoft.com", securePassword).WithAuthority("https://login.microsoftonline.com/e4c9ab4e-bd27-40d5-8459-230ba2a757fb/").ExecuteAsync().GetAwaiter().GetResult();
						// Test AcquireTokenInteractive
						//AuthenticationResult result = app.AcquireTokenInteractive(scopes).WithAuthority("https://login.microsoftonline.com/e4c9ab4e-bd27-40d5-8459-230ba2a757fb/").ExecuteAsync().Result;
						Console.WriteLine(result.Account.Username + " -> " + result.AccessToken);
					}
					catch (Exception e)
					{
						Console.Error.WriteLine(e.Message);
						Console.Error.WriteLine(e.StackTrace);
					}
				}
				Console.Write("Continue? Y/N:");
				flag = Console.ReadLine();
			} while (flag.Trim().ToUpper().Equals("Y"));
			Console.ReadLine();
		}
	}
The result: 
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/0pdDp.png
