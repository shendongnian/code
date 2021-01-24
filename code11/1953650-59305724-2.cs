    public partial class Fixture
    {
        [JsonProperty("fixture_id")]
        public long FixtureId { get; set; }
    
        [JsonProperty("league_id")]
        public long LeagueId { get; set; }
    
        [JsonProperty("homeTeam")]
        public Team HomeTeam { get; set; }
    
        [JsonProperty("awayTeam")]
        public Team AwayTeam { get; set; }
    
        [JsonProperty("lineups")]
        public Dictionary<string, Lineup> Lineups { get; set; }
    }
