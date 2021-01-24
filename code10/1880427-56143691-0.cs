    public class Jobb
    {
        public DateTime? starttid { get; set; }
        public DateTime? sluttid { get; set; }
        [Timestamp]
        public byte[] rowversion { get; set; }
        [Required]
        public string service { get; set; }
        [Key]
        public int jobb_key { get; set; }
    }
