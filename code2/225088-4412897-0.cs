    class Office : Building
    {
        public string Company { get; set; }
    
        public Office() : this(null)
        {
        }
    
        public Office(string address, decimal price, string company)
            : base(address, price)
        {
            Company = company;
            BuildingType = BuildingType.Office; // Don't wanna repeat statement
        }
    }
