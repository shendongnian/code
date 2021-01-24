    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult DownloadFile(int id)
        {
            byte[] fileContent = GetImageFromDataBase(id);
            string extension = //get image extension;
            return File(fileContent, "image/" + extension, "filename from db");
        }
    }
