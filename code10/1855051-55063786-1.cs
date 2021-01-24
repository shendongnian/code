        string json = JsonConvert.SerializeObject(user);
        HttpResponseMessage response;
        using (var client = new HttpClient())
        {
            response = client.PostAsync(
                "url",
                 new StringContent(json, Encoding.UTF8, "application/json"));
        }
        DisplayAlert("Alert", json, "OK");
        DisplayAlert("test", response, "test");
