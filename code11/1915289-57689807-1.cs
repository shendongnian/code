    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Product()
        {
            ProductModel productModel = GetProductModels();
            
            return View(productModel);
        }
        [HttpPost]
        public IActionResult Product(ProductModel productModel)
        {
            int productCount = productModel.ProductItems.Count;
            return View(productModel);
        }
        private ProductModel GetProductModels()
        {
            ProductModel productModel = new ProductModel();
            productModel.ProductItems.Add(new ProductItem() { Name = "Product_1", Type = "A", QuantityOnHand = 50, AmountOrdered = 20, AmountToReturn = 5, PaybackAmount = 110, ReasonForReturn = "Looking for something else!"});
            productModel.ProductItems.Add(new ProductItem() { Name = "Product_2", Type = "B", QuantityOnHand = 50, AmountOrdered = 20, AmountToReturn = 5, PaybackAmount = 110, ReasonForReturn = "Looking for something else!" });
            productModel.ProductItems.Add(new ProductItem() { Name = "Product_3", Type = "C", QuantityOnHand = 50, AmountOrdered = 20, AmountToReturn = 5, PaybackAmount = 110, ReasonForReturn = "Looking for something else!" });
            productModel.ProductItems.Add(new ProductItem() { Name = "Product_4", Type = "D", QuantityOnHand = 50, AmountOrdered = 20, AmountToReturn = 5, PaybackAmount = 110, ReasonForReturn = "Looking for something else!" });
            return productModel;
        }`enter code here`
    }
