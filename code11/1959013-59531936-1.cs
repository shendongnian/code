    public class Request
    {
        public Request(string type = "", string userName = "", string key = "")
        {
             Type = type;
             Username = userName;
             Key = key;
        }
        public string Type { get; }     // <-- No setter = immutable.
        public string Username { get; }
        public string Key { get; }
    }
