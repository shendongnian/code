    class HomeController : Controller
    {
         readonly Func<IFooService> _fooServiceFactory;
         public HomeController(Func<IFooService> fooServiceFactory)
         {
             _fooServiceFactory = fooServiceFactory;
         }
         public ActionResult SomeAction() 
         {
             var service = _fooServiceFactory(); // Resolves IFooService dynamically
             service.DoStuff();
         }
    }
