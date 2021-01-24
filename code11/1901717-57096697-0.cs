    public partial class Lead
    {
        [Key]
        public int leadid { get; set; }
        public int saleno { get; set; }
        public int office { get; set; }
        public string package { get; set; }
        public datetime saledate { get; set; }
    }
    
