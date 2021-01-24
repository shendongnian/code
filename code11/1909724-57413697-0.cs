    public class PatchRequest
    {
        public string Name { get; }
        public string Address { get; }
        public PatchRequest(string name, string address) { Name = name; Address = address; }
    
        // extra fields
        [JsonExtensionData]
        private IDictionary<string, JToken> _extraStuff;
    }
