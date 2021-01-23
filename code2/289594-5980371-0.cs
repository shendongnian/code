    class First
    {
        [Key]
        public int Id { get; set; }
    }
    
    class Second
    {
        [Key, ForeignKey("First")]
        public int Id { get; set; }
        public First First { get; set; }
    }
