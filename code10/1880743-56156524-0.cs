    public static class DisplayConstants
    {
        public const string Make = "Make of Car";
        public const string PurchaseYear = "Year of Purchase";
    }
    
    public class EditCarViewModel{
    
        [Display(Name = DisplayConstants.Make)]
        public string Make { get; set; }
    
        [Display(Name = DisplayConstants.PurchaseYear)]
        public int PurchaseYear { get; set; }
    }
    
    public class Car
    {
        public int Id { get; set; }
    
        [Display(Name = DisplayConstants.Make)]
        public string Make { get; set; }
    
        [Display(Name = DisplayConstants.PurchaseYear)]
        public int PurchaseYear { get; set; }
    }
