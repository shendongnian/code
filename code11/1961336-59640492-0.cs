    public class Client
    {
        public int Id { get; set; }
    
        public string LastName { get; set; }
    
        public string Gender { get; set; }
    
        public DateTime DateOfBirth { get; set; }
    
        public virtual Address Address { get; set; } // <-- Here it is
    }
