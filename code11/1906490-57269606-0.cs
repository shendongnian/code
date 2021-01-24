    public class InvalidIdAttributeAdapter : AttributeAdapterBase<InvalidIdAttribute>
    {
        private readonly InvalidIdAttribute _attribute;
        private readonly IProductService _productService;
        public InvalidIdAttributeAdapter(InvalidIdAttribute attribute, IStringLocalizer stringLocalizer, IProductService _productService)
            : base(attribute, stringLocalizer)
        {
            _attribute = attribute;
            _productService = productService;
        }
        public override void AddValidation(ClientModelValidationContext context)
        {
            var invalidIds = _productService.GetIds()…;
            // …
        }
    }
