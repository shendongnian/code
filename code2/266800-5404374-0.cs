    interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
    interface IAddress
    {
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string City { get; set; }
        string Province { get; set; }
        string Country { get; set; }
    }
    class CustomerRecord : IPerson, IAddress // ActiveRecord object map to table...
    {  
        // IPerson members...
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // IAddress members...
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
    }
