    public class User
    {
        public int GenderId { get; set; }
        [ForeignKey("Id")]//Gender Primary key
        public virtual Gender Gender { get; set; }
    }
