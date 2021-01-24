    public class TokenResponse
    {
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
    
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
    
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
    
        [JsonProperty(PropertyName = "app_id")]
        public string AppId { get; set; }
    
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
    
        [JsonProperty(PropertyName = "nonce")]
        public string Nonce { get; set; }
    }
    
    public class Amount
    {
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }
    
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
    
    public class PurchaseUnit
    {
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
    }
    
    public class OrdersRequest
    {
        [JsonProperty(PropertyName = "intent")]
        public string Intent { get; set; }
    
        [JsonProperty(PropertyName = "purchase_units")]
        public PurchaseUnit[] PurchaseUnits { get; set; }
    }
    
    public static void CreateToken()
    {
        var client = new HttpClient();
        byte[] authBytes = Encoding.ASCII.GetBytes("user:pass");
        string base64Auth = Convert.ToBase64String(authBytes);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Auth);
    
        var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("grant_type", "client_credentials") });
        var response = client.PostAsync(new Uri("https://api.sandbox.paypal.com/v1/oauth2/token"), content).Result;
        if (response.IsSuccessStatusCode)
        {
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Content.ReadAsStringAsync().Result);
            GetClient(tokenResponse.AccessToken);
        }
    }
    
    public static HttpClient GetClient(string token)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    
        var request = new OrdersRequest
        {
            Intent = "CAPTURE",
            PurchaseUnits = new PurchaseUnit[] { new PurchaseUnit
                {
                    Amount = new Amount
                    {
                        CurrencyCode = "USD",
                        Value = "100.0"
                    }
                }
            }
        };
    
        var jsonContent = JsonConvert.SerializeObject(request);
        var content = new StringContent(jsonContent, Encoding.ASCII, "application/json");
    
        var response = client.PostAsync(new Uri("https://api.sandbox.paypal.com/v2/checkout/orders"), content).Result;
        if (response.IsSuccessStatusCode)
        {
            var responseString = response.Content.ReadAsStringAsync().Result;
        }
        return client;
    }
