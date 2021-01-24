    public async Task<IEnumerable<UserDto>> GetAllAsync(string token, string baseUrl)
    {
         using (HttpClient client = new HttpClient())
    
        //Setting up the response...         
        using (HttpResponseMessage res = await client.GetAsync(baseUrl + 
        "users?access-token=" + token))
        using (HttpContent content = res.Content)
        {
            string json = await content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserDto>>(json);
            
            return users;
        }
    }
