    public class User
    {
        public Guid UserId { get; set; }
        public Participant Participant { get; set; }
        public Guid? ParticipantId { get; set; }
    }
    public class Participant
    {
        public Guid ParticipantId { get; set; }    
        public User User { get; set; }    
        public Guid? UserId { get; set; }    
    }
