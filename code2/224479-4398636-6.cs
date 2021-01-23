    // just for the example
    public class Cart
    {
        public string Foo { get; set; }
    }
    public class HomeController : ContentController<Cart>
    {
        public new ActionResult Index()
        {
            Cart cart = null; //new Cart { Foo = "this is my 1st cart test" };
            if (cart != null)
                return Index(cart);
            else
                return base.Index();
        }
    }
