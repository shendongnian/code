    public class Scorebot
        {
            public string Messagedata { get; set; }
            public string CurrentScoreCt { get; set; }
            public string CurrentScoreT { get; set; }
            public string TeamNameCt { get; set; }
            public string TeamNameT { get; set; }
            public List<Players> PlayersCt { get; set; }
            public List<Players> PlayersT { get; set; }
        }
    
        public class Players
        {
            public string Nickname { get; set; }
            public string Weapon { get; set; }
            public string Health { get; set; }
            public string Armor { get; set; }
            public string Money { get; set; }
            public string Adr { get; set; }
            public string Kills { get; set; }
            public string Assists { get; set; }
            public string Deaths { get; set; }
        } 
