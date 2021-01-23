    public class ProductExtendedViewModel : ProductViewModel
    {
        public ProductExtendedViewModel()
        {
        }
        public ProductExtendedViewModel(ProductViewModel viewModel)
        {
            Name = viewModel.Name;
            Product = viewModel.Product;
        }
        public string ExtendedName { get; set; }
    }
