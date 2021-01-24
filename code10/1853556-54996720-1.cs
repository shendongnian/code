    static async Task Main() {
        using (var httpClient = new HttpClient()) {
            double totalUsage;
            double allowableUsage;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // this line can be removed in .NET Core
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://login.xfinity.com/login")) {
                var data = new Dictionary<string, string> {
                    {"user", Username}
                    , {"passwd", Password}
                    , {"s", "oauth"}
                    , {"continue", "https://oauth.xfinity.com/oauth/authorize?client_id=my-account-web&prompt=login&redirect_uri=https%3A%2F%2Fcustomer.xfinity.com%2Foauth%2Fcallback&response_type=code"}
                };
                var content = string.Join("&", data.Select(x => $"{x.Key}={WebUtility.UrlEncode(x.Value)}"));
                request.Content = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");
                await httpClient.SendAsync(request);
            }
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://customer.xfinity.com/apis/services/internet/usage")) {
                var response = await httpClient.SendAsync(request);
                var responseStream = await response.Content.ReadAsStreamAsync();
                var streamReader = new StreamReader(responseStream);
                var responseContent = streamReader.ReadToEnd();
                var parsedResponse = JObject.Parse(responseContent);
                var usageMonths = parsedResponse["usageMonths"];
                var currentMonthUsage = usageMonths.Last;
                totalUsage = currentMonthUsage.Value<double?>("totalUsage") ?? 0;
                allowableUsage = currentMonthUsage.Value<double?>("allowableUsage") ?? 0;
            }
            Console.WriteLine($"Allowable: {allowableUsage}");
            Console.WriteLine($"Total    : {totalUsage}");
            Console.ReadKey();
        }
    }
