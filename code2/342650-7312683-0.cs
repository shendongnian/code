    public class MyViewModel
    {
        [Required(ErrorMessage = "This is a required field.")]
        [DataType(DataType.Currency)]
        [Range(1.00, 500.00, ErrorMessage = "Products can not be free.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Price")]
        public double Price { get; set; }
    }
