    public class Player
    {
        public Player() { Seasons = new List<PlayerSeason> { }; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public IEnumerable<PlayerSeason> Seasons { get; private set; } 
        public void AddSeason(PlayerSeason playerSeason)
        {
            //some code that adds a season.  may check if already exists. whatever your business rules say to do
            Seasons.Add(playerSeason);
        }
    }
    
    public class Season 
    {
        public int Id { get; set; }
        public string season { get; set; }
    }
    
    public class PlayerSeason
    {
        public int PlayerId {get; set; }
        public int SeasonId { get; set; }
        public int JerseyNumber { get; set; }
        public int HeightInches { get; set; }
        public int WeightPounds { get; set; }
    }
