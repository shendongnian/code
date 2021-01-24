    public class Address
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public virtual ICollection<CustomerAddress> CustomerAddresses{ get; set;}
    }
    
    public class Customer
    {
            public int Id { get; set; }  
            public string FirstName { get; set; }  
            public string LastName { get; set; }
            public virtual ICollection<CustomerAddress> CustomerAddresses{ get; set; }
    }
    
    public class CustomerAddress
    {
        public int CustomerId{ get; set; }
        public int AddressId{ get; set; }
    
        public virtual Address Address{ get; set; }
        public virtual Customer Customer{ get; set; }
    }
