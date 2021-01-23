    public class DirectoryAccount
    {
        // normal deserialization
        public string DisplayName { get; set; }
        // these properties are set in OnDeserialized
        public string UserName { get; set; }
        public string Domain { get; set; }
        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // SAMAccountName is not deserialized to any property
            // and so it is added to the extension data dictionary
            string samAccountName = (string)_additionalData["SAMAccountName"];
            Domain = samAccountName.Split('\\')[0];
            UserName = samAccountName.Split('\\')[1];
        }
        public DirectoryAccount()
        {
            _additionalData = new Dictionary<string, JToken>();
        }
    }
    string json = @"{
      'DisplayName': 'John Smith',
      'SAMAccountName': 'contoso\\johns'
    }";
    DirectoryAccount account = JsonConvert.DeserializeObject<DirectoryAccount>(json);
    Console.WriteLine(account.DisplayName);
    // John Smith
    Console.WriteLine(account.Domain);
    // contoso
    Console.WriteLine(account.UserName);
    // johns
