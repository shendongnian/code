    [RoutePrefix("demo")]
    public class DemoController : Controller
    {
      [Route("")]
      public ActionResult Index()  { } // default route: /demo
      [Route("admin/create")]
      public ActionResult Create() { } // /demo/admin/create
    
      [Route("admin/edit/{id}")]
      public ActionResult Edit(int id) { } // /demo/admin/edit/5
    }
