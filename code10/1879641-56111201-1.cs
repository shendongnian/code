    static async void PostWebHookAsync(string output_message)
    {
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "www.mywebsitelink"))
            {
                string jsonValue = JsonConvert.SerializeObject(new
                {
                    text = output_message
                });
                request.Content = new StringContent(jsonValue, Encoding.UTF8, "application/json");
                var response = await httpClient.SendAsync(request);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Content);
            }
        }
    }
