    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            testAsync();
        }
        public async Task testAsync()
        {
            GoogleService googleS = new GoogleService();
            // use your token here
            var email = await googleS.GetEmailAsync("", "");
            Console.WriteLine(email);
        }
        public class GoogleProfile
        {
            [Preserve]
            [JsonConstructor]
            public GoogleProfile() { }
            public string sub { get; set; }
            public string name { get; set; }
            public string given_name { get; set; }
            public string profile { get; set; }
            public string picture { get; set; }
            public string email { get; set; }
            public string email_verified { get; set; }
            public string locale { get; set; }
        }
        public class GoogleService
        {
            public async Task<string> GetEmailAsync(string tokenType, string accessToken)
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var json = await httpClient.GetStringAsync("https://www.googleapis.com/oauth2/v3/userinfo");//https://www.googleapis.com/userinfo/email?alt=json");
                var profile = JsonConvert.DeserializeObject<GoogleProfile>(json);
                Console.WriteLine(json);
                Console.WriteLine(profile);
                return profile.email;
            }
        }
    }
