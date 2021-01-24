    static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args)
        {
            var email = "yourserviceaccountmail";
            ServiceAccountCredential credential = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(email)
                {
                    Scopes = new[] { PlaycustomappService.Scope.Androidpublisher }
                }.FromPrivateKey("client_secrets.json"));
            CustomApp appMetadata = new CustomApp();
            appMetadata.Title = "YOUR APP";
            appMetadata.LanguageCode = "en_US";
            // Create the service.
            var service = new PlaycustomappService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Custom Apps API Sample",
            });
            var acc = new AccountsResource(service);
            using (var stream = new FileStream("app-release.apk", FileMode.Open))
            {
                long devIAccountd = 12345678L;
                var app = acc.CustomApps.Create(appMetadata, devIAccountd, stream, "application/octet-stream");
                var response = await app.UploadAsync();
                if (response.Exception != null)
                {
                    Console.WriteLine("Someting went wrong:");
                    Console.WriteLine(response.Exception.Message);
                }
                if (response.Status == Google.Apis.Upload.UploadStatus.Completed)
                {
                    Console.WriteLine("Succeeded!");
                }
            }
        }
