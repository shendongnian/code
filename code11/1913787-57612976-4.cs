     public POSViewModel()
    {   
        CartViewModel = new CartViewModel();    
        ProductsViewModel = new ProductsViewModel(this);
    }
 
    public class ProductsViewModel : Conductor<object>
    {
        public BindableCollection<ProductModel> Products { get; set; }
        private CartViewModel CVM { get; set; }
        public ProductsViewModel(POSViewModel PVM)
        {
 						this.CVM = PVM.CartViewModel;
        }
        public void AddProdClick(ProductModel productModel)
        {
						CVM.Add(productModel)
        }
    }
