    using (var client = new WebClient())
    {
        var requestUri = new Uri("https://services.yesmail.com/enterprise/subscribers");
        var cache = new CredentialCache();
        var nc = new NetworkCredential("user/user1", "password");
        cache.Add(requestUri, "Basic", nc);
        client.Credentials = cache;
        var values = new NameValueCollection
        {
            { "EmailAddress", "test999@test1.com" },
            { "FirstName", "first" },
            { "LastName", "last" },
        };
        var result = client.UploadValues(requestUri, values);
        Console.WriteLine(Encoding.Default.GetString(result));
    }
