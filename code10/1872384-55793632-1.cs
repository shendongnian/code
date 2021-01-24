     public class ProductOptionValue
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ValueId { get; set; }
        public int OptionId { get; set; }
        [Required]
        [MaxLength(32)]
        public String ValueName { get; set; }
        [RelatedField(Table = "ProductOption", ForeignKey = "OptionId", PrimaryKey="Id")]
        public ProductOption ProductOption{ get; set; }
    }
        public async Task<ReturnString> SaveProductOption(ProductOptionRequest request)
           {
            ReturnString returnString = new ReturnString();
            
            foreach (ProductValuesRequest valueRequest in request.productValues)
            {
                ProductOption details = new ProductOption();
                details.OptionName = request.Name;
                ProductOptionValue res = new ProductOptionValue();
                res.ValueName = valueRequest.ValueName;
                res.ProductOption =result ;
                object response = await 
                productOptionValueRepository.InsertAsync(res, true);
              }
                returnString.StringValue = result != null ? $"{request.Name} saved successfully" : "";
             return returnString;          
     }
