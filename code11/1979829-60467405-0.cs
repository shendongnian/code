        private const string URL = "https://api.skinbaron.de/";
        private static string urlParameters = "?api_key=123"; // I have replaced the "123" with my apikey
        private static string apiKey = "";
        static void Main(string[] args)
        {
            using (var webClient = new WebClient()) {
                webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var postDictionary = new Dictionary<string, string>() {
                    {"apikey", apiKey}
                };
                var responseBody = webClient.UploadString(URL, JsonConvert.SerializeObject(postDictionary));
            }
        }
