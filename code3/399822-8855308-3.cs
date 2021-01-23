    class Employee
    {
        public List<Address> Address { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        
        public string EmpId { get; set; }
    }
    class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
    }
