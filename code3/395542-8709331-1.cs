    class Customer
    {
        // You can either pass the UID through the constructor or 
        // expose a public setter to allow modification of the property
        public Customer(string uid)
        {
            this.UID = uid;
        }
        public string UID { get; private set; }
        public string Name { get; set; }
        public string Count { get; set; }
    }
