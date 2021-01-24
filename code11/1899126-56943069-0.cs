    [Table("participants")]
    public class participant
    {
        [Key]
        public int ID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        [ForeignKey("Confirmations")]
        public string alias { get; set; }
        
        public virtual ICollection<ParticipantConfirmations> Confirmations { get; set; } = new List<ParticipantConfirmation>();
    }
    [Table("confirmedParticipants")]
    public class ParticipantConfirmation
    {
        [Key]
        public string alias { get; set; }
        public bool is_confirmed { get; set; }
        // etc.
    }
