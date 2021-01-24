    public class GamesList
    {
        [JsonProperty("game_count")]
        public int GameCount { get; set; }
        [JsonProperty("games")]
        public List<Game> Games { get; set; }
    }
    public class Game
    {
        [JsonProperty("appid")]
        public string AppId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("playtime_2weeks")]
        public int PlayedMinutesInTheLastTwoWeeks { get; set; }
        // And so on. Depending on what you need.
    }
