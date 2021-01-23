    class First
    {
        [Key]
        public Guid FirstId { get; set; }
    }
    class Second
    {
        [Key]
        public Guid FirstId { get; set; }
        public First First { get; set; }
    }
    class SecondMapping : EntityTypeConfiguration<Second>
    {
        public SecondMapping()
        {
            this.HasRequired(s => s.First);
        }
    }
