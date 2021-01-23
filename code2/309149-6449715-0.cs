    public class CategoryViewModel
    {
        public string Title { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
    public class ProductViewModel
    {
        public string Description { get; set; }
    }
