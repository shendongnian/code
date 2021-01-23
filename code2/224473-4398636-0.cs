    // just for the example
    public class Cart
    {
        public string Foo { get; set; }
    }
    public class HomeController : ContentController<Cart>
    {
        public override ActionResult Index(Cart item)
        {
            return View();
        }
    }
