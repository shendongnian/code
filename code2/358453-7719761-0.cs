    public class Address {
        [Key]
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual StoreLocation StoreLocation { get; set; }
        public virtual Employee Employee { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
    }
    public class Customer {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
    public class StoreLocation {
        [Key]
        public int Id { get; set; }
        public string ShortCode { get; set; }
        public string Description { get; set; }
        public virtual Address Address { get; set; }
    }
    public class Employee {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
