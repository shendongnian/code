    class Cookie
    {
         [JsonProperty("value")]
         public string Value;
         [JsonPropery("expiry")]
         public DateTime Expiry;
    }
    var cookieJar = new Dictionary<string, Cookie>()
