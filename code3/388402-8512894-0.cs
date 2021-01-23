    public class ComplexDetailsViewModel 
    {
        [Required]//Works for just the Id property
        public int Id { get; set; }
        public string DisplayValue1 { get; set; }
        public string DisplayValue2 { get; set; }
        // ...
    }
