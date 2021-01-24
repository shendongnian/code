    public class TestRun
    {
        [JsonProperty("@id")]
        public string Id { get; set; }
        [JsonProperty("@name")]
        public string Name { get; set; }
        [JsonProperty("@fullname")]
        public string FullName { get; set; }
        [JsonProperty("@testcasecount")]
        public string TestCaseCount { get; set; }
        [JsonProperty("test-suite")]
        public TestSuite[] TestSuite { get; set; }
    }
