    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid UserId { get; set; }
        public Participant Participant { get; set; }
        public Guid? ParticipantId { get; set; }
    }
    public class Participant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ParticipantId { get; set; }
        public User User { get; set; }
        public Guid? UserId { get; set; }
    }
