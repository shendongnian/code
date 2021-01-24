    public class AppSettings
    {
        public int TokenLifeTime { get; set; } = 450;
        public List<ServersList> ServersList { get; set; } = new List<ServersList>
        {
            new ServersList { Url = "www.google.com", IsHttpsAllowed = false},
            new ServersList { Url = "www.hotmail.com", IsHttpsAllowed = true}
        };
    }
    public class ServersList
    {
        public string Url { get; set; }
        public bool IsHttpsAllowed { get; set; }
    }
