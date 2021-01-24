    class LoginData
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
    class OtherClassUsingYourTypes
    {
        public OtherClassUsingYourTypes(string jsonData)
        {
            this.loginDictionary = JsonConvert.DeserializeObject<Dictionary<string, LoginData>>(jsonData);
        }
        private Dictionary<string, LoginData> loginDictionary;
        public void FillLogin(string loginKey)
        {
            LoginData loginValues = loginDictionary[loginKey];
            browser.FillIn(userNameFieldId).With(loginValues.Username);
            browser.FillIn(passwordFieldId).With(loginValues.Password);
        }
    }
