        public class gamePlayLogs
        {
            [JsonProperty("status")]
            public string status { get; set; }
            [JsonProperty("data")]
            public Dictionary<string, Dictionary<string, Month>> Data { get; set; }
        }
        public partial class Month
        {
            [JsonProperty("consecutive")]
            public int[][] Consecutive { get; set; }
            [JsonProperty("non_consecutive")]
            public int[] NonConsecutive { get; set; }
        }
