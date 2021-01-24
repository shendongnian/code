    public class ConversionViewModel
    {
        public int Id { get; set; }
    
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(Resources))]
        [StringLength(100, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources))]
        public string Name { get; set; }
    
        [Range(1, int.MaxValue, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Resources))]
        public int FeedId { get; set; }
    
        [Range(1, int.MaxValue, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Resources))]
        public int FieldId { get; set; }
    
        public Operator Operator { get; set; }
    
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(Resources))]
        [StringLength(100, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources))]
        public string Expression { get; set; }
    }
