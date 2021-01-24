    public class Person
    {
        [Key]
        public int Id { get; private set; }
        [EmailAddress]
        public string? Email { get; set; }
        public int? Cin { get; set; }
        public string? Address { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone, Required]
        public int PhoneNumber { get; set; }
        public Person(int PhoneNumber, string Name, string Email = null, int? Cin = null, string Address = null)
        {
            this.PhoneNumber = PhoneNumber;
            this.Name = Name;
            this.Email = Email;
            this.Address = Address;
            this.Cin = Cin;
        }
        public Person()
        {
        }
    }
