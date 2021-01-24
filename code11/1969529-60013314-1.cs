    User user = new User
    {
        Username = username,
        Password = password
    };
    string json = JsonConvert.SerializeObject(user);
    StringContent content = new StringContent(josn, Encoding.UTF8, "application/json"); 
    HttpResponseMessage response = await client.PostAsync("auth", content);
