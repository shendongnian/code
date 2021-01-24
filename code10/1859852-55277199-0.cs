        public class Activity
        {
            public string Type { get; set; }
            public string AgentMACID { get; set; }
            private string AgentMACID2 { set { AgentMACID = value; } } // used to map the other field of json
            public PlateNumber PlateNumber { get; set; }
        }
