     public class AppSettings
    {
        public int TokenLifeTime { get; set; } = 450;
        public List<KeyValuePair<string, ServersList>> Urls { get; set; } = new List<KeyValuePair<string, ServersList>>
        {
            new KeyValuePair<string, ServersList>("www.google.com",new ServersList {IsHttpsAllowed = false}),
            new KeyValuePair<string, ServersList>("www.hotmail.com", new ServersList {IsHttpsAllowed = true})
        };
        public List<ServersList> ServersList { get; set; } = new List<ServersList>
        {
            new ServersList {IsHttpsAllowed = false},
            new ServersList {IsHttpsAllowed = true}
        };
    }
    public class ServersList
    {
        public bool IsHttpsAllowed { get; set; }
    }
