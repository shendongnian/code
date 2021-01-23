    public class ServicesController : Controller
    {
        public ActionResult GetFoo(int id)
        {
            var dbResult = SomeDbUtil.GetFoo(id);
            return this.Json(dbResult);
        }
    }
