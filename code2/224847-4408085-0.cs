    public class Game 
    { 
        public String Id { get; set; } 
        public String CreatorId { get; set; } 
     
        public List<Player> Players { get; set; } 
        public String PlayerId { get; set; } 
    } 
     
    public class Player 
    { 
        public String Id { get; set; } 
        public String Name { get; set; } 
        public String Position { get; set; }
        
        public Move(string NewPosition);
        public event EventHandler onMoved;
    }
