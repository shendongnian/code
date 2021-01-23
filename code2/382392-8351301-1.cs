    public class AjaxController : Controller
    {
        [HttpPost]
        public JsonResult Foo(FooModel model)
        {
            string message = _ajaxService.Foo(model);
    
            return Json(message);
        }
    }
