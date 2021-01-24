    public class Products
    {
        public string ProductName { get; set; }
        public double DiscountPrice { get; set; }
    }
    List<Products> lstProduct = new List<Products>();
            lstProduct.Add(new Products { ProductName = "Product1", DiscountPrice = 50.52 });
            lstProduct.Add(new Products { ProductName = "Product2", DiscountPrice = 49.50 });
            lstProduct.Add(new Products { ProductName = "Product3", DiscountPrice = 52.53 });
            lstProduct.Add(new Products { ProductName = "Product4", DiscountPrice = 100.00});
            lstProduct.Add(new Products { ProductName = "Product5", DiscountPrice = 40.40 });
            foreach (var item in lstProduct.OrderBy(d => d.DiscountPrice))
            {
                item.ProductName.ToString();
            }
