     public class Team {
        public int TeamId { get; set; }
        ...
        public virtual ICollection<Player> Players { get; set; }
    }
