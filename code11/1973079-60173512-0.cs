    public class ServiceController : Controller
    {
       public ActionResult DownloadFile(string id)
       {
           CustomDocumentObj document = new CustomDocumentObj(Int32.Parse(id));
           // OPTIONAL - validation to check if it is allowed to download this file.
           string filetype = Helpers.GetMimeType(document.FilePath);
           return File(document.FilePath, filetype, Path.GetFileName(document.FilePath));
       }
    } 
