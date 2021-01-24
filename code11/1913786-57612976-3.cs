    public class ProductsViewModel : Conductor<object>
    {
        public BindableCollection<ProductModel> Products { get; set; }
        private CartViewModel CVM { get; set; }
        public ProductsViewModel(CartViewModel CVM)
        {
 						this.CVM = CVM;
        }
        public void AddProdClick(ProductModel productModel)
        {
						CVM.Add(productModel)
        }
    }
