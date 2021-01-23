    public class Country2Language {
        [Key] 
        [Column(Order = 0)] 
        [ForeignKey("CountryShortName")] 
        public int CountryShortname{ get; set; } 
        [Key] 
        [Column(Order = 1)] 
        [ForeignKey("LanguagesID")] 
        public int LanguagesID { get; set; } 
        public DateTime DateCreated {get; set;}
    }
