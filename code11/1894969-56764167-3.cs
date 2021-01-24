        public class Order
        {
            public string CustomerCode { get; set; }
            [JsonConverter(typeof(ArrayConverter), "Stop")]
            public List<Stop> Stops { get; set; }
            [JsonConverter(typeof(ArrayConverter), "Job")]
            public List<Job> Jobs { get; set; }
        }
