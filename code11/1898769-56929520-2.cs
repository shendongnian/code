    class ProductAViewModel : IViewModel {
        //You can use both IProduct or the derived type (i.e ProductA) as the constructor param
        public ProductAViewModel(ProductA a)
        {
    
        }
    }
    
    class ProductBViewModel : IViewModel {
        public ProductBViewModel(IProduct b)
        {
    
        }
    }
