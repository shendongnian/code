    User user = new User
    {
        Username = username,
        Password = password
    };
    HttpResponseMessage response = await client.PostAsJsonAsync("auth", user);
