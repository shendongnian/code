    public class SampleController : Controller
    {
        //
        // GET: /Sample/
        [HttpPost]
        public ActionResult Create(Information information)
        {
            var byteArray = Encoding.ASCII.GetBytes(information.FirstName + ";" + information.SureName);
            var stream = new MemoryStream(byteArray);
            return File(stream, "text/plain", "your_file_name.txt");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
