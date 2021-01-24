        public class Data
        {
            public string vehicle_number { get; set; }
            public string device_id { get; set; }
            public string type { get; set; }
            public List<string> cordinate { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string motion_status { get; set; }
            public string motion_state { get; set; }
            public int speed { get; set; }
            public string orientation { get; set; }
            public int last_received_at { get; set; }
            public string share_link { get; set; }
            public CustomData custom_data { get; set; }
        }
        public class RootObject
        {
            public Data data { get; set; }
        }
        public class CustomData
        {
        }
