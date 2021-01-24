    static Lazy<HttpClient> client = new Lazy<HttpClient>();
    private async void button1_Click(object sender, EventArgs e) {
        var urlx = "https://xxxxx.xxxxxxx.com/api/";
        var usr = "xxxxxxxxxxx";
        var pwd = "xxxx";
        Card card = new Card();
        //populate as needed
        TransactionRequest<Card> item = new TransactionRequest<Card>();
        //populate as needed
        //set payment method accordingly
        item.payment_method["card"] = card;
        
        Uri url = new Uri(string.Format(urlx));
        string response = await PostAsync(url, item);
        if (response != null) {
            Console.WriteLine(response);
        } else {
            Console.WriteLine("nothing");
        }
    }
    public async Task<string> PostAsync<T>(Uri url, T value) {
        try {
            string json = JsonConvert.SerializeObject(value);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.Value.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        } catch (Exception e) {
            //TODO: log error
            return null;
        }
    }
