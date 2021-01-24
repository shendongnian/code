    public class Client
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string CompanyName { get; set; }
        public string ApplicationUserId { get; set; }
        public List<Athlete> Athletes { get; set; }
    }
    public class Athlete
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        //public Client Client { get; set; }
    }
