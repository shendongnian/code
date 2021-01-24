    using (HttpClient httpClient = new HttpClient())
    {
       httpClient.BaseAddress = new Uri("https://api.com/");
       httpClient.DefaultRequestHeaders.Accept.Clear();
       httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
       httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
       HttpResponseMessage response = httpClient.GetAsync("v1/registrants/search?email=" + email).Result;
       string json = response.Content.ReadAsStringAsync().Result;
       ResultModel result = JsonConvert.DeserializeObject<ResultModel>(json);
       int count = result.items.Count();
    }
