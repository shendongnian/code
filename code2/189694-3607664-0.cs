    public class Store
    {
        public Store()
        {
            // Ready to go!
            Products = new List<Product>();
        }
        public string Id {get;set;}
        public IList<Product> Products {get;set;}
    }
