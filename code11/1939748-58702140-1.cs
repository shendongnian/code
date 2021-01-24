    public class Envelope
    {
        [Key]
        public Guid EnvelopeId { get; set; }
        public virtual ICollection<Recipient> Recipients { get; set; } = new Hashset<Recipient>();
        ...
    }
