    public class ProductModalViewModel
    {
        public ProductModalViewModel()
        {
            Product = new ProductDto();
            Specs = new List<SpecDto>();
        }
        public ProductDto Product { get; set; }
        public List<SpecDto> Specs { get; set; }
    }
