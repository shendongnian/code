    // just for the example
    public class Cart
    {
        public string Foo { get; set; }
    }
    public class HomeController : ContentController<Cart>
    {
        public override ActionResult Index(Cart item)
        {
            var cart = new Cart {Foo = "this is my cart test"};
            return View(cart);   
        }
    }
