    [HttpPost]
    public class StatusController : Controller
    {
        public JsonResult CheckStatus()
        {
            return Json(new { status = "active" });
        }
    }
