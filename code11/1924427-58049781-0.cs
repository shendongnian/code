     public partial class GameResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
    public partial class Response
    {
        [JsonProperty("game_count")]
        public long GameCount { get; set; }
        [JsonProperty("games")]
        public Game[] Games { get; set; }
    }
    public partial class Game
    {
        [JsonProperty("appid")]
        public long Appid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("playtime_2weeks", NullValueHandling = NullValueHandling.Ignore)]
        public long? Playtime2Weeks { get; set; }
        [JsonProperty("playtime_forever")]
        public long PlaytimeForever { get; set; }
        [JsonProperty("img_icon_url")]
        public string ImgIconUrl { get; set; }
        [JsonProperty("img_logo_url")]
        public string ImgLogoUrl { get; set; }
        [JsonProperty("has_community_visible_stats")]
        public bool HasCommunityVisibleStats { get; set; }
        [JsonProperty("playtime_windows_forever")]
        public long PlaytimeWindowsForever { get; set; }
        [JsonProperty("playtime_mac_forever")]
        public long PlaytimeMacForever { get; set; }
        [JsonProperty("playtime_linux_forever")]
        public long PlaytimeLinuxForever { get; set; }
    }
