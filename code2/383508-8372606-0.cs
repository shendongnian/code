    public class FileController : Controller {
        public ActionResult Default(string folder, string file) {
            return View(folder + "/" + file);
        }
    }
