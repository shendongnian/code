    string json = JsonConvert.SerializeObject(user);
    HttpResponseMessage response;
    using (var client = new HttpClient())
    {
        response = client.PostAsync(
            "url",
             new StringContent(json, Encoding.UTF8, "application/json").Result);
    }
    var body = response.Content.ReadAsStringAsync().Result;
    DisplayAlert("Alert", json, "OK");
    DisplayAlert("test", body, "test");
