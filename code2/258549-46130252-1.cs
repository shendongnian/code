    public class HomeController : Controller
    {
        public ActionResult UploadFile()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult UploadFile(MyModal Modal)
        {
                string DocumentName = string.Empty;
                string Description = string.Empty;
    
                if (!String.IsNullOrEmpty(Request.Form["DocumentName"].ToString()))
                    DocumentName = Request.Form["DocumentName"].ToString();
                if (!String.IsNullOrEmpty(Request.Form["Description"].ToString()))
                    Description = Request.Form["Description"].ToString();
                
                if (!String.IsNullOrEmpty(Request.Form["FileName"].ToString()))
                    UploadedDocument = Request.Form["FileName"].ToString();
    
                HttpFileCollectionBase files = Request.Files;
    
                string filePath = Server.MapPath("~/Root/Documents/");
                if (!(Directory.Exists(filePath)))
                    Directory.CreateDirectory(filePath);
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                        UploadedDocument = fname;
                    }
                    else
                    {
                        fname = file.FileName;
                        UploadedDocument = file.FileName;
                    }
                    file.SaveAs(fname);
                    return RedirectToAction("List", "Home");
    }
