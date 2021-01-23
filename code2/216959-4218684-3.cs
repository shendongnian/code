    public class Note 
    {
       public DateTime CreatedAt { get; set; }
       public string Content { get; set; }
    }
    public class Account 
    {
        public ICollection<Notes> Notes { get; }
    }
    public class Appointment 
    {
        public ICollection<Notes> Notes { get; }
    }
