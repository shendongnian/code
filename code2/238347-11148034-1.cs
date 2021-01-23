    public class HomeController : Controller
    {
        public ActionResult Index (T a)
        {
          return View();
        }
    
        public JsonResult A([DynamicJson] JsonValue value)
        {
          dynamic t = value.AsDynamic();
    
          if (t.Name.IsEmpty())
          {
            t = new // t is dynamic, so I figure just create the structure you need directly
            {
                Name = "myname",
                D = new // Associative array notation (woot!): 
                {
                    a = "a",
                    b = "b",
                    c = "c" 
                }
            };
          }
    
          return Json(t);
        }
    }
