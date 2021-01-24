    internal class AspspListResponseResource 
    {
        // Report with the list of supported ASPSPs. Each ASPSP will include the list of available API endpoints and the logo.
        [JsonProperty(PropertyName = "aspsp-list")]
        public Aspsp[] AspspList { get; set; }
        public AspspListResponseResource() { /* Empty constructor to create the object */ }
         public AspspListResponseResource(string jsonString)
         {
            AspspListResponseResource root = JsonConvert.DeserializeObject<AspspListResponseResource>(jsonString);
            this.AspspList = root.AspspList;
         }
    }
    internal class Aspsp 
    {
        // ASPSP Id
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = "";
        // Bank Identifier Code
        [JsonProperty(PropertyName = "bic")]
        public string Bic { get; set; } = "";
        // IBAN Bank Identifier
        [JsonProperty(PropertyName = "bank-code")]
        public string BankCode { get; set; } = "";
        // ASPSP Code to use in the endpoint
        [JsonProperty(PropertyName = "aspsp-cde")]
        public string AspspCde { get; set; } = "";
        // Institution name
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = "";
        // Bank logo location
        [JsonProperty(PropertyName = "logoLocation")]
        public string LogoLocation { get; set; } = "";
        // Bank Supported API List
        [JsonProperty(PropertyName = "api-list")]
        public ApiLink[] ApiList { get; set; }
    }
    internal class ApiLink 
    {
        // Consents Link List
        [JsonProperty(PropertyName = "consents")]
        public string[] Consents { get; set; } = { "" };
        // Payments Link List
        [JsonProperty(PropertyName = "payments")]
        public string[] Payments { get; set; } = { "" };
        // Accounts Link List
        [JsonProperty(PropertyName = "accounts")]
        public string[] Accounts { get; set; } = { "" };
        // Balances Link List
        [JsonProperty(PropertyName = "balances")]
        public string[] Balances { get; set; } = { "" };
        //// Transaction Link List
        //[JsonProperty(PropertyName = "transaction")]
        //public string[] Transaction { get; set; } = { "" };
        //
        //// Funds-Confirmations Link List
        //[JsonProperty(PropertyName = "funds-confirmations")]
        //public string[] FundsConfirmations { get; set; } = { "" };
        
    }
