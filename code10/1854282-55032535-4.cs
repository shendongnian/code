    public class JsonInfo
    {
        public string uuid { get; set; }
        public string call_start_time { get; set; }
        public string call_duration { get; set; }
        public string created_on { get; set; }
        public string cost { get; set; }
        public string call_type { get; set; }
        public string answered { get; set; }
        public string has_recording { get; set; }
        public string call_route { get; set; }
        public string is_fax { get; set; }
        public From from { get; set; }
        public To to { get; set; }
        public AnsweredBy answered_by { get; set; }
    }
    public class From
    {
        public string uuid { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string number { get; set; }
    }
    public class To
    {
        public string uuid { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string number { get; set; }
    }
    public class AnsweredBy
    {
        public string uuid { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string number { get; set; }
    }
    //Create a model to show your information
    public class  DisplayJsonInfo
        {
            public string uuid { get; set; }
            public string call_start_time { get; set; }
            public string call_duration { get; set; }
            public string created_on { get; set; }
            public string cost { get; set; }
            public string from_uuid { get; set; }
            public string from_type { get; set; }
            public string from_name { get; set; }
            public string from_nickname { get; set; }
        }
