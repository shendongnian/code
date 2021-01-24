    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string Function { get; set; }
        public Guid Customer { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string LanguageCode { get; set; }
        public bool IsMainContact { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public Guid CustomerId { get; set; }
        // If you want to use class reference navigation property (also called as "hard reference").
        // That can be used in "$expand" or "$select" for example.
        // Uncomment the following line:
        // public Customer Customer { get; set }
    }
