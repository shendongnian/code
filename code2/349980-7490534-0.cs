    public class ImageController : Controller
    {
        public ActionResult Index(string filename)
        {
            return Redirect("~/Content/images/" + filename);
        }
    }
