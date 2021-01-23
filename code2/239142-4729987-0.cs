    public class MyViewModel
    {
        [Required]
        public string CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
