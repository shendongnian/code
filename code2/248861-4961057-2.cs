    public class AnimalViewModel
    {
        [DisplayName("Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string AnimalName { get; set; }
    
        [DisplayName("Gattung")]
        [Required(ErrorMessage = "Genus is required")]    
        public int? SelectedGenusId { get; set; } 
    
        public IEnumerable<SelectListItem> Genus { get; set; }
    }
