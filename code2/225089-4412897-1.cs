    class Building
    {
        public BuildingType BuildingType { get; protected set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
    
        public Building() : this("Unknown", 0m)
        {
        }
    
        public Building(string address, decimal price)
        {
            BuildingType = BuildingType.General;
            Address = address;
            Price = price;
        }
    }
