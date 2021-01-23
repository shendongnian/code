    public class Todo
    {
        [Required]
        public int ID { get; set; }
        public int? OrderId { get; set; } //Not required
        public string Description { get; set; }
        public bool Finished { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Priority { get; set; } //Not required
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
    }
