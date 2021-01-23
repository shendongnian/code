    public partial class Family
    { 
        public int Id { get; set; }
        public string FamilyName { get; set; }
    
        public virtual Address Address { get; set; }
    }
    public partial class Address
    {
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string TownCity { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    
        public virtual Family Family { get; set; }
    }
