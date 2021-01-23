    public class MyViewModel
    {
        [Required]
        [DisplayName("Profession")]
        public string Profession { get; set; } 
        
        public IEnumerable<SelectListItem> ProfessionList { get; set; }
    }
