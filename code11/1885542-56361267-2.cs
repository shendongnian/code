    public class PlaceController : Controller
    {
        [HttpPost]
        public JsonResult Search(string place)
        {
           // process
           return Json(place, JsonRequestBehavior.AllowGet);
        }
    }
