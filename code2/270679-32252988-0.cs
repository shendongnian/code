    public class FooBar
    {
        public string api_key { get; set; }
        public string action { get; set; }
        public string store_id { get; set; }
        public User user { get; set; }
    }
    public class User
    {
        public int id { get; set; }
        public string screen_name { get; set; }
    }
