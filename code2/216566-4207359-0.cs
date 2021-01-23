    using (var client = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "key", "This is a test that posts this string to a Web server." }
        };
        string url = "http://www.contoso.com/PostAccepter.aspx";
        byte[] result = client.UploadValues(url, values);
        Console.WriteLine(Encoding.UTF8.GetString(result));
    }
