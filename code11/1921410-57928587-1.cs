    class Cookie
    {
         [JsonProperty("value")]
         public string Value;
         [JsonPropery("expiry")]
         public DateTime Expiry;
    }
    var cookieJar = new Dictionary<string, Cookie>();
    cookieJar.Add("cookie_name1", new Cookie
    {
        Value = cookie_value1,
        Expiry = DateTime.Now
    });
    // With json.net you can simply use
    var str = JsonConvert.SerializeObject(cookieJar);
