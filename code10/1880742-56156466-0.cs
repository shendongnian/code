    [MetadataType(typeof(CarModelMetaData))]
    public class EditCarViewModel{
        public string Make { get; set; }.
        public int PurchaseYear { get; set; }
    }
    [MetadataType(typeof(CarModelMetaData))]
    public class CreateCarViewModel{
        public string Make { get; set; }
        public int PurchaseYear { get; set; }
    }
    
    public class CarModelMetaData{
    
        [Display(Name = "Make of Car")]
        public string Make { get; set; }
    
        [Display(Name = "Year of Purchase")]
        public int PurchaseYear { get; set; }
    }
