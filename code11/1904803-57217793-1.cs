    public class EmuItem
    {
        public int Id { get; set; }
        public string SearchName { get; set; }
        [Required(ErrorMessage = "Please enter value for {0}")]
        public string Name { get; set; }
        
        public int Age { get; set; }
    }
