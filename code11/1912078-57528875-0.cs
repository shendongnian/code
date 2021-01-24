    class returnObject
    {
        public Company company { get; set; }
        public Animals animals { get; set; }
    }
    class Company
    {
        public string name { get; set; }
        public decimal netWorth { get; set; }
        public string country { get; set; }
    }
    class Animals
    {
        public string name { get; set; }
        public string species { get; set; }
        public float jumpHeight { get; set; }
    }
