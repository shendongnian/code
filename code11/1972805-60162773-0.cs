    public class AppSettings
    {
        public int TokenLifeTime { get; set; } = 450;
        public Dictionary<string, ServersList> Urls { get; set; } = new Dictionary<string, ServersList>
        {
            {"www.google.com", new ServersList {IsHttpsAllowed = false}},
            { "www.hotmail.com", new ServersList {IsHttpsAllowed = true}}
        };
    }
    public class ServersList
    {
        public bool IsHttpsAllowed { get; set; }
    }
