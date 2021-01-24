    static async void PostWebHookAsync(string Aoutput_message)
    {
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "www.mywebsitelink"))
            {
                //request.Content = new StringContent("{\"text\":\"Hello, World!\"}", Encoding.UTF8, "application/json");  // - original do not delete
                string jsonValue = new JavaScriptSerializer().Serialize(new
                {
                    text = Aoutput_message,
                });
                request.Content = new StringContent(jsonValue, Encoding.UTF8, "application/json");
                var response = await httpClient.SendAsync(request);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Content);
            }
        }
    }
