    public partial class ContactListAPI_Result
    {
        [JsonProperty("vid")]
        public long Vid { get; set; }
        [JsonProperty("portal-id")]
        public long PortalId { get; set; }
        [JsonProperty("is-contact")]
        public bool IsContact { get; set; }
        [JsonProperty("profile-url")]
        public Uri ProfileUrl { get; set; }
        [JsonProperty("properties")]
        public Dictionary<string, Dictionary<string, string>> Properties { get; set; }
    }
    public partial class ContactListAPI_Result
    {
        public static ContactListAPI_Result FromJson(string json) 
            => JsonConvert.DeserializeObject<ContactListAPI_Result>(json);
        //public static ContactListAPI_Result FromJson(string json) 
        //  => JsonConvert.DeserializeObject<ContactListAPI_Result>(json, Converter.Settings);
    }
    public static void toto()
    {
        string input = @"    {
        ""vid"": 2301,
        ""portal-id"": 5532227,
        ""is-contact"": true,
        ""profile-url"": ""https://app.hubspot.com/contacts/5532227/contact/2301"",
        ""properties"": {
            ""firstname"": {
                ""value"": ""Carlos""
            },
            ""lastmodifieddate"": {
                ""value"": ""1554886333954""
            },
            ""company"": {
                ""value"": ""Khaos Control""
            },
            ""lastname"": {
                ""value"": ""Swannington""
            }
        }
    }";
        var foo = ContactListAPI_Result.FromJson(input);
    }
    
