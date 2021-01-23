    public class ErrorController : Controller
    {
        public ActionResult FileUploadError()
        {
            return View(); //returns view "FileUploadError"
        }
    }
    public class FileUploadController : Controller // the controller you use to upload your files
    {
        public ActionResult Error()
        {
            return View(); //return view "Error"
        }
        public ActionResult Index(HttpPostedFileBase excelFile)  // action from your post
        {
            //... do the upload stuff
            else
            {
                return RedirectToAction("Error"); // if you want to use the Error action in this controller;
                // or
                return RedirectToAction("FileUploadError", "Error"); // if you want to use the action on the ErrorController
            }   
        }
    }
