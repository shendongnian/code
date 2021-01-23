        public class FilesController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetFile(string fileName)
        {...
        }
    }
