    public class software 
    {
        [JsonProperty("softwares")]
        public List<string> name { get; set; }
        public string version { get; set; }
        public string fixVersion { get; set; }
        public string vulnerabilities { get; set; }
    }
