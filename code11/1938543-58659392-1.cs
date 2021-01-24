    public class ProductUpdateDescriptionAndBrand
    {
        public string Id { get; set; }
        public BrandDescription BrandDescription { get; set; }
    }
    public class ProductDetailView : ProductListView
    {
        public BrandDescription BrandDescription { get; set; }
    }
