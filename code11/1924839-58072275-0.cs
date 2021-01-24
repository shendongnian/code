     public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        //Dates
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateDate { get; set; }
        //Relationships
        [Required]
        public int Clientid { get; set; }
        public Client Client { get; set; }
        public virtual List<Spread> Spreads { get; set; }
    }
