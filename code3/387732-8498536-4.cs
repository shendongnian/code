    [Table("tblUsers")]
    class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
    }
