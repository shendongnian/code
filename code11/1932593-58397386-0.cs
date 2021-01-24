    public class Response
    {
        [JsonProperty("DataTable.RemotingVersion")]
        public object RemotingVersion { get; set; }
        public string XmlSchema { get; set; }
        public string XmlDiffGram { get; set; }
    }
    public class Table
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
    }
