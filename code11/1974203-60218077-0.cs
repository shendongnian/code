    class ProductsPage
    {
        private ProductsRepository _rep;
        public ProductsPage(ProductsRepository rep)
        {
           _rep=rep;
        }
        public List<BaseInfo> LoadProductPage()
        {
           List<BaseInfo> baseInfo = new List<BaseInfo>();
           baseInfo.Add(_rep.GetProducts(100));
    
           return baseInfo;
        }
    }
