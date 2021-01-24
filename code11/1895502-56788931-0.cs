    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Auth.OAuth2.Requests;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;
    
    namespace GoogleApiTest
    {
        // Source: https://developers.google.com/identity/sign-in/android/offline-access
        class Program
        {
            static void Main(string[] args)
            {
                var authCode = "YOUR_FRESH_SERVER_AUTH_CODE";
    
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"client_secret.json");
                var config = File.ReadAllText(path, Encoding.UTF8);
    
                GoogleClientSecrets clientSecrets = GoogleClientSecrets.Load(new FileStream(path, FileMode.Open));
    
                var request = new AuthorizationCodeTokenRequest()
                {
                    ClientId = clientSecrets.Secrets.ClientId,
                    ClientSecret = clientSecrets.Secrets.ClientSecret,
                    RedirectUri = "",
                    Code = authCode,
                    GrantType = "authorization_code"
                };
    
                var tokenResponse = request.ExecuteAsync(new System.Net.Http.HttpClient(), "https://www.googleapis.com/oauth2/v4/token", new System.Threading.CancellationToken(), Google.Apis.Util.SystemClock.Default).GetAwaiter().GetResult();
    
                Console.ReadLine();
            }
        }
    }
