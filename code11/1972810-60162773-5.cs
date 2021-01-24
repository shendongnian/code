    public class AppSettings
    {
        public int TokenLifeTime { get; set; } = 450;
        public List<Server> ServersList { get; set; } = new List<Server>
        {
            new Server { Url = "www.google.com", IsHttpsAllowed = false},
            new Server { Url = "www.hotmail.com", IsHttpsAllowed = true}
        };
    }
    public class Server
    {
        public string Url { get; set; }
        public bool IsHttpsAllowed { get; set; }
    }
