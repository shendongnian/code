    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString("http://data.fcc.gov/api/license-view/basicSearch/getLicenses?searchValue=Verizon+Wireless&format=json");
                var serializer = new JavaScriptSerializer();
                var model = serializer.Deserialize<FCC>(json);
                return View(model.Licenses.License);
            }
        }
    }
