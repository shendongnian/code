    public class SomeController : Controller
    {
        private readonly IDoThings thingsDoer;
        public SomeController(IDoThings thingsDoer)
        {
             this.thingsDoer = thingsDoer;
        }
        public ActionResult DoThings()
        {
            this.thingsDoer.DoThings();
            return View();
        }
    }
