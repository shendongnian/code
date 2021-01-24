    public class User 
    {
        public int Id { get; set; }
        [NotMapped]
        public string IgnoredField { get; set; }
    }
