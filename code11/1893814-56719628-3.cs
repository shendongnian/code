        public class Player
        {
            public string PlayerKey { get; set; }
            public string PlayerId { get; set; }
            public Name Name { get; set; }
            public string EditorialPlayerKey { get; set; }
            public string EditorialTeamKey { get; set; }
            public string EditorialTeamFullName { get; set; }
            public string EditorialTeamAbbr { get; set; }
            public Week ByeWeeks { get; set; }
            public string UniformNumber { get; set; }
            public string DisplayPosition { get; set; }
            public Photo Headshot { get; set; }
            public string ImageUrl { get; set; }
            public string IsUndroppable { get; set; }
            public string PositionType { get; set; }
            public Position[] EligiblePositions { get; set; }
        }
        public class Name
        {
            public string Full { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
        }
        public class Photo
        {
            public string Url { get; set; }
            public string Size { get; set; }
        }
        public class Week
        {
            [JsonProperty("week")]
            public int Number { get; set; }
        }
        public class Position
        {
            [JsonProperty("position")]
            public string Name { get; set; }
        }
