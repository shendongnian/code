    public async Task<JObject> FetchData()
    {
    	using (HttpClient httpClient = new HttpClient())
    	{
    		 httpClient.BaseAddress = new Uri("https://api.com/");
    		 httpClient.DefaultRequestHeaders.Accept.Clear();
    		 httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    		 httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    		 HttpResponseMessage response = httpClient.GetAsync("v1/registrants/search?email=" + email).Result;
    		 string response = await response.Content.ReadAsStringAsync();
    		 return JsonConvert.DeserializeObject<JObject>(response);
    	}
    }
