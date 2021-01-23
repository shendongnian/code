    public class HomeController : Controller
    {
        public ActionResult Upload()
        {
            XDocument doc;
            using (var sr = new StreamReader(Request.InputStream))
            {
                doc = XDocument.Load(sr);
            }
            return Content(doc.ToString());
        }
    }
