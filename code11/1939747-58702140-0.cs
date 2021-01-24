    public class Recipient
    {
        [Key]
        public long RecipientId { get; set; }
        public Guid? EnvelopeId1 { get; set; }
        [ForeignKey(nameof(EnvelopeId1))]
        public virtual Envelope Envelope { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string Name { get; set; }
        public string RoleName { get; set; }
        public int RoutingOrder { get; set; }
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
        public Recipient() { }
    }
