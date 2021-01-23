    public class PingPongPlayer
    {
        [Key]
        public string Name { get; set; }
        public string EMail { get; set; }
        public int Ranking { get; set; }
    }
    public class Match
    {
        [Key]
        public int Id { get; set; }
        
        public string FrkPlayer1 { get; set; }
        public string FrkPlayer2 { get; set; }
        [ForeignKey("FrkPlayer1")]
        public PingPongPlayer Player1 { get; set; }
        [ForeignKey("FrkPlayer2")]
        public PingPongPlayer Player2 { get; set; }
        public DateTime MatchDate { get; set; }
        public bool AlreadyPlayed { get; set; }
        public string Player1Name
        {
            get { return Player1.Name; }
        }
        public string Player2Name
        {
            get { return Player2.Name; }
        }
    }
